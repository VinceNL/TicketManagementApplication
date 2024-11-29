using Domain.DTO.Request;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TicketRepository(AppDBContext context) : GenericRepository<Ticket>(context), ITicketRepository
    {
        public List<Ticket> GetTickets(GetTicketsRequest request)
        {
            IQueryable<Ticket> query = context.Set<Ticket>()
                .Include(x => x.Category)
                .Include(x => x.Priority)
                .Include(x => x.Product)
                .Include(x => x.User)
                .Include(x => x.AssignedTo);

            if (request is null) return query.ToList();

            if (!string.IsNullOrEmpty(request.summary))
            {
                query = query.Where(x => (EF.Functions.Like(x.Summary, $"%{request.summary}%")));
            }

            if (request.ProductId != null && request.ProductId.Count() > 0)
            {
                query = query.Where(x => request.ProductId.Contains(x.ProductId));
            }

            if (request.CategoryId != null && request.CategoryId.Count() > 0)
            {
                query = query.Where(x => request.CategoryId.Contains(x.ProductId));
            }

            if (request.PriorityId != null && request.PriorityId.Count() > 0)
            {
                query = query.Where(x => request.PriorityId.Contains(x.PriorityId));
            }

            if (request.Status != null && request.Status.Count() > 0)
            {
                query = query.Where(x => request.Status.Contains(x.Status));
            }

            if (request.RaisedBy != null && request.RaisedBy.Count() > 0)
            {
                query = query.Where(x => request.RaisedBy.Contains(x.RaisedBy));
            }

            return query.OrderByDescending(x => x.RaisedDate).ToList();
        }
    }
}
