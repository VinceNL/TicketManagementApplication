using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        List<Ticket> GetTickets(GetTicketsRequest request);
        List<ChartResponse> GetLastYearsTickets();
        List<ChartResponse> ChartByCategory(string category);
        List<ChartResponse> GetSummary();
    }
}
