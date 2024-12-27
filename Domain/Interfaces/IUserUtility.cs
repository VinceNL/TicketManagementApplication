using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserUtility
    {
        Task<User?> GetCurrentUserAsync();
    }
}
