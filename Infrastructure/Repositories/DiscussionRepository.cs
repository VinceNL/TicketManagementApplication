using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DiscussionRepository : GenericRepository<Discussion>, IDiscussionRepository
    {
        private readonly AppDBContext _dbContext;

        public DiscussionRepository(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Discussion> GetDiscussions(int ticketId)
        {
            return _dbContext.Set<Discussion>()
                .Include(x => x.Attachments)
                .Include(x => x.User)
                .Where(x => x.TicketId == ticketId)
                .OrderBy(x => x.CreatedDate)
                .ToList();
        }
    }
}
