using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Common;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<User> _signInManager;

        public AccountService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
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

            var result = await _signInManager.UserManager.CreateAsync(user, password);
            return new BaseResponse
            {
                IsSuccess = result.Succeeded
            };
        }

        public async Task<BaseResponse<string>> VerifyUser(string email, string password)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(email);
            if (user is null)
            {
                return new BaseResponse<string>
                {
                    IsSuccess = false,
                    ErrorMessage = "User is not found!"
                };
            }

            var result = await _signInManager.UserManager.CheckPasswordAsync(user, password);
            return new BaseResponse<string>
            {
                IsSuccess = result,
                ErrorMessage = result ? string.Empty : "Password is incorrect!",
                Value = result ? user.UserName! : string.Empty
            };
        }
    }
}
