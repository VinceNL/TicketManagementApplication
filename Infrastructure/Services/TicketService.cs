using Domain.Interfaces;
using Domain.DTO.Response;
using Domain.DTO.Request;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Services
{
    public class TicketService(IUnitOfWork unitOfWork) : ITicketService
    {
        public GetTicketResponse FindTicket(int ticketId)
        {
            var result = unitOfWork.Repository<Ticket>().GetByIdAsync(ticketId);
            if (result is null) throw new Exception("Ticket not found");

            return new GetTicketResponse
            {
                TicketId = result.TicketId,
                Summary = result.Summary,
                Description = result.Description ?? string.Empty,
                ProductId = result.ProductId,
                CategoryId = result.CategoryId,
                PriorityId = result.PriorityId,
                Status = result.Status ?? string.Empty,
                RaisedBy = result.User?.Email ?? string.Empty,
                CreatedDate = result.RaisedDate,
                ExpectedDate = result.ExpectedDate
            };
        }

        public List<GetTicketResponse> GetTickets(GetTicketsRequest request)
        {
            List<Ticket> result = unitOfWork.TicketRepository.GetTickets(request);

            return result.Select(x => new GetTicketResponse
            {
                TicketId = x.TicketId,
                Summary = x.Summary,
                Product = x.Product?.ProductName ?? string.Empty,
                Category = x.Category?.CategoryName ?? string.Empty,
                Priority = x.Priority?.PriorityName ?? string.Empty,
                Status = x.Status ?? string.Empty,
                RaisedBy = x.User?.Email ?? string.Empty,
                CreatedDate = x.RaisedDate,
                ExpectedDate = x.ExpectedDate
            }).ToList();
        }
    }
}
