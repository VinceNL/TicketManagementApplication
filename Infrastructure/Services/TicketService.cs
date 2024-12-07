using Domain.Interfaces;
using Domain.DTO.Response;
using Domain.DTO.Request;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Common;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Services
{
    public class TicketService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : ITicketService
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
                AssignedToId = result.AssignedToId ?? string.Empty,
                RaisedBy = result.User?.Id ?? string.Empty,
                RaisedByName = result.User?.Email ?? string.Empty,
                CreatedDate = result.RaisedDate,
                ExpectedDate = result.ExpectedDate,
                ClosedBy = result.ClosedBy ?? string.Empty,
                ClosedDate = result.ClosedDate,
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
                AssignedToId = x.AssignedToId ?? string.Empty,
                RaisedBy = x.User?.Id ?? string.Empty,
                RaisedByName = x.User?.Email ?? string.Empty,
                CreatedDate = x.RaisedDate,
                ExpectedDate = x.ExpectedDate
            }).ToList();
        }

        public async Task<BaseResponse> UpdateTicket(UpdateTicketRequest request)
        {
            var result = new BaseResponse();
            result.IsSuccess = false;

            var currentTicket = unitOfWork.Repository<Ticket>().GetByIdAsync(request.TicketId);
            if (currentTicket is null)
            {
                result.ErrorMessage = "Ticket not found";
                return result;
            }

            currentTicket.ProductId = request.ProductId!.Value;
            currentTicket.CategoryId = request.CategoryId!.Value;
            currentTicket.PriorityId = request.PriorityId!.Value;
            currentTicket.AssignedToId = request.AssignedToId;

            currentTicket.Status = request.Status;
            currentTicket.LastUpdateDate = DateTime.Now;

            if (request.Status == Constants.STATUS_CLOSED)
            {
                currentTicket.ClosedDate = DateTime.Now;
                var currentUser = httpContextAccessor.HttpContext?.User.Identities.FirstOrDefault(x => x.IsAuthenticated)?.Name;

                if (currentUser is null)
                {
                    result.ErrorMessage = "User not found";
                    return result;
                }
                currentTicket.ClosedBy = currentUser;
            }

            unitOfWork.TicketRepository.Update(currentTicket);

            var dbResult = await unitOfWork.SaveChangesAsync() > 0;

            if (dbResult)
            {
                result.IsSuccess = true;
            }
            else
            {
                result.ErrorMessage = "Failed to update ticket";
            }

            return result;
        }
    }
}
