using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DiscussionRepository(AppDBContext dbContext) : GenericRepository<Discussion>(dbContext), IDiscussionRepository
    {
        public List<Discussion> GetDiscussions(int ticketId)
        {
            return dbContext.Set<Discussion>()
                .Include(x => x.Attachments)
                .Include(x => x.User)
                .Where(x => x.TicketId == ticketId)
                .OrderBy(x => x.CreatedDate)
                .ToList();
        }
    }
}
