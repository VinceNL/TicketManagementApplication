using Domain.DTO.Request;
using Domain.DTO.Response;
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
            query = ApplyFilters(request, query);

            return query.OrderByDescending(x => x.RaisedDate).ToList();
        }

        public List<ChartResponse> ChartByCategory(string category)
        {
            IQueryable<IGrouping<string, Ticket>> data;
            category = category.ToLower();
            switch (category)
            {
                case "category":
                    data = context.Set<Ticket>()
                        .Include(x => x.Category)
                        .GroupBy(x => x.Category.CategoryName);
                    break;
                case "product":
                    data = context.Set<Ticket>()
                        .Include(x => x.Product)
                        .GroupBy(x => x.Product.ProductName);
                    break;
                case "priority":
                    data = context.Set<Ticket>()
                        .Include(x => x.Priority)
                        .GroupBy(x => x.Priority.PriorityName);
                    break;
                default:
                    return null;
            }

            return data.Select(x => new ChartResponse
            {
                Label = x.Key,
                Value = x.Count()
            }).ToList();
        }


        public List<ChartResponse> GetSummary()
        {
            return context.Set<Ticket>()
                .GroupBy(x => x.Status)
                .Select(x => new ChartResponse
                {
                    Label = x.Key ?? "Not Set",
                    Value = x.Count()
                }).ToList();
        }

        public List<ChartResponse> GetLastYearsTickets()
        {
            var endMonth = DateTime.Now;
            var startMonth = endMonth.AddMonths(-11);

            var query = context.Set<Ticket>()
                .Where(x => x.RaisedDate >= startMonth && x.RaisedDate <= endMonth)
                .GroupBy(x => new { x.RaisedDate.Year, x.RaisedDate.Month })
                .Select(g => new
                {
                    g.Key.Month,
                    g.Key.Year,
                    Count = g.Count()
                })
                .OrderBy(x => x.Year).ThenBy(x => x.Month)
                .ToList();

            return query.Select(x => new ChartResponse
            {
                Label = new DateTime(x.Year, x.Month, 1).ToString("MMM yyyy"),
                Value = x.Count
            }).ToList();
        }

        private static IQueryable<Ticket> ApplyFilters(GetTicketsRequest request, IQueryable<Ticket> query)
        {
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
                query = query.Where(x => request.CategoryId.Contains(x.CategoryId));
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

            return query;
        }
    }
}
