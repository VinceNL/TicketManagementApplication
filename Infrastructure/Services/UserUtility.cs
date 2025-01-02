using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Infrastructure.Services
{
    public class UserUtility(
    UserManager<User> userManager,
    IHttpContextAccessor httpContext,
    ProtectedSessionStorage protectedSession) : IUserUtility
    {
        public async Task<User?> GetCurrentUserAsync()
        {
            var emailResult = await protectedSession.GetAsync<string>("email");
            if (!string.IsNullOrEmpty(emailResult.Value))
            {
                return await userManager.FindByEmailAsync(emailResult.Value);
            }

            var userId = httpContext.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
            {
                return await userManager.FindByIdAsync(userId);
            }

            return null;
        }
    }
}
