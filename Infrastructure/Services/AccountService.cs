using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using Infrastructure.Common;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class AccountService(
        SignInManager<User> signInManager,
        IUnitOfWork unitOfWork,
        IWebHostEnvironment environment,
        IUserUtility userUtility) : IAccountService
    {
        public async Task<BaseResponse> ChangePassword(ChangePasswordRequest request)
        {
            BaseResponse response = new();
            response.IsSuccess = false;

            var user = await GetCurrentUserAsync();
            if (!user.IsSuccess)
            {
                response.ErrorMessage = user.ErrorMessage;
                return response;
            }

            var changePasswordResult = await signInManager.UserManager.ChangePasswordAsync(user.Value, request.CurrentPassword, request.NewPassword);
            if (changePasswordResult.Succeeded)
            {
                response.IsSuccess = true;
                await ConfirmAccount(user.Value);
            }
            else
            {
                response.ErrorMessage = changePasswordResult.Errors.FirstOrDefault()?.Description ?? "Unknown error";
            }
            return response;
        }

        private async Task ConfirmAccount(User user)
        {
            if (!user.AccountConfirmed)
            {
                user.AccountConfirmed = true;
                unitOfWork.Repository<User>().Update(user);
                await unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<BaseResponse<User>> GetCurrentUserAsync()
        {
            BaseResponse<User> response = new();
            var user = await userUtility.GetCurrentUserAsync();

            if (user == null)
            {
                response.ErrorMessage = "User not found";
            }
            else
            {
                response.Value = user;
                response.IsSuccess = true;
            }

            return response;
        }



        public async Task<BaseResponse> RemoveUser(string email)
        {
            BaseResponse response = new();
            response.IsSuccess = false;

            var user = await signInManager.UserManager.FindByEmailAsync(email);
            if (user is null)
            {
                response.ErrorMessage = "User not found - " + email;
                return response;
            }

            user.isDeleted = true;
            var result = await signInManager.UserManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                response.ErrorMessage = result.Errors.FirstOrDefault()?.Description ?? "Unknown error";
                return response;
            }

            response.IsSuccess = true;
            return response;
        }

        public async Task<BaseResponse> ResetAvatar()
        {
            BaseResponse response = new();
            response.IsSuccess = false;
            var uploadPath = Path.Combine(environment.WebRootPath, "uploads", "avatars");

            var currentUser = await GetCurrentUserAsync();
            if (!currentUser.IsSuccess)
            {
                response.ErrorMessage = currentUser.ErrorMessage;
                return response;
            }

            string previousAvatar = string.Empty;
            if (currentUser.Value.Avatar != Constants.DEFAULT_AVATAR)
            {
                previousAvatar = currentUser.Value.Avatar ?? string.Empty;
                previousAvatar = Path.Combine(uploadPath, previousAvatar);
                if (File.Exists(previousAvatar))
                {
                    File.Delete(previousAvatar);
                }

                currentUser.Value.Avatar = Constants.DEFAULT_AVATAR;

                var updateResult = await signInManager.UserManager.UpdateAsync(currentUser.Value);

                if (updateResult.Succeeded)
                {
                    response.IsSuccess = true;
                }
                else
                {
                    response.ErrorMessage = updateResult.Errors.FirstOrDefault()?.Description ?? "Unknown error";
                }
            }

            return response;
        }

        public async Task<BaseResponse<string>> UploadAvatar(IBrowserFile image)
        {
            BaseResponse<string> response = new();
            response.IsSuccess = false;
            string previousAvatar = string.Empty;
            var uploadPath = Path.Combine(environment.WebRootPath, "uploads", "avatars");

            var currentUser = await GetCurrentUserAsync();
            if (!currentUser.IsSuccess)
            {
                response.ErrorMessage = currentUser.ErrorMessage;
                return response;
            }

            if (image is not null)
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                if (currentUser.Value.Avatar != Constants.DEFAULT_AVATAR)
                {
                    previousAvatar = currentUser.Value.Avatar ?? string.Empty;
                    previousAvatar = Path.Combine(uploadPath, previousAvatar);

                    if (File.Exists(previousAvatar))
                    {
                        File.Delete(previousAvatar);
                    }
                }

                var fileExtension = Path.GetExtension(image.Name);
                var fileName = $"{currentUser.Value.Email}{fileExtension}";
                var filePath = Path.Combine(uploadPath, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.OpenReadStream().CopyToAsync(fileStream);
                }

                currentUser.Value.Avatar = fileName;

                var updateResult = await signInManager.UserManager.UpdateAsync(currentUser.Value);
                if (updateResult.Succeeded)
                {
                    response.IsSuccess = true;
                    response.Value = fileName;
                }
                else
                {
                    response.ErrorMessage = updateResult.Errors.FirstOrDefault()?.Description ?? "Unknown error";
                }
            }
            return response;
        }

        public List<GetUserResponse> GetUsers()
        {
            var roles = unitOfWork.Repository<IdentityUserRole<string>>().ListAll()
                .Select(x => new
                {
                    x.UserId,
                    x.RoleId,
                    Role = Constants.UserRoles[x.RoleId]
                }).ToList();

            return unitOfWork.Repository<User>().ListAll()
                .Where(x => !x.isDeleted)
                .Select(x => new GetUserResponse
                {
                    Id = x.Id,
                    Email = x.Email ?? string.Empty,
                    Avatar = x.Avatar ?? string.Empty,
                    Role = roles.FirstOrDefault(r => r.UserId == x.Id)?.Role ?? "User",
                    AccountConfirmed = x.AccountConfirmed
                }).ToList();
        }

        public async Task<BaseResponse> RegisterUser(RegisterUserRequest request)
        {
            var user = new User
            {
                Email = request.Email,
                UserName = request.Email,
                AccountConfirmed = false
            };

            string password = Constants.DEFAULT_PASSWORD;

            var result = await signInManager.UserManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await signInManager.UserManager.AddToRoleAsync(user, request.Role);
                return new BaseResponse
                {
                    IsSuccess = true,
                };
            }
            return new BaseResponse
            {
                IsSuccess = false,
                ErrorMessage = result.Errors.FirstOrDefault()?.Description ?? "Unknown error"
            };
        }

        public async Task<BaseResponse<string>> VerifyUser(string email, string password)
        {
            var user = await signInManager.UserManager.FindByEmailAsync(email);
            if (user is null || user.isDeleted)
            {
                return new BaseResponse<string>
                {
                    IsSuccess = false,
                    ErrorMessage = "User is not found!"
                };
            }

            var result = await signInManager.UserManager.CheckPasswordAsync(user, password);
            return new BaseResponse<string>
            {
                IsSuccess = result,
                ErrorMessage = result ? string.Empty : "Password is incorrect!",
                Value = result ? user.UserName! : string.Empty
            };
        }
    }
}
