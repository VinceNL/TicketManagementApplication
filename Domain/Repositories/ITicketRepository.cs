using Domain.DTO.Request;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        List<Ticket> GetTickets(GetTicketsRequest request);
    }
}
