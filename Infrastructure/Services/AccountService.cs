using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using Infrastructure.Common;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class AccountService(SignInManager<User> signInManager, IUnitOfWork unitOfWork) : IAccountService
    {
        public List<GetUserResponse> GetUsers()
        {
            return unitOfWork.Repository<User>().ListAll().Select(x => new GetUserResponse
            {
                Id = x.Id,
                Email = x.Email,
                Avatar = x.Avatar
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
            return new BaseResponse
            {
                IsSuccess = result.Succeeded
            };
        }

        public async Task<BaseResponse<string>> VerifyUser(string email, string password)
        {
            var user = await signInManager.UserManager.FindByEmailAsync(email);
            if (user is null)
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
