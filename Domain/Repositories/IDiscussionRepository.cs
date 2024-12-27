using Domain.Entities;

namespace Domain.Repositories
{
    public interface IDiscussionRepository : IGenericRepository<Discussion>
    {
        List<Discussion> GetDiscussions(int ticketId);
    }
}
