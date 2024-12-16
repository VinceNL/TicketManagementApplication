using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using Infrastructure.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services
{
    public class TicketService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment) : ITicketService
    {
        public async Task<BaseResponse<int>> CreateTicket(CreateTicketRequest request)
        {
            var createTicketResult = new BaseResponse<int> { IsSuccess = false };
            var uploadPath = Path.Combine(webHostEnvironment.WebRootPath, "uploads", "attachments");

            try
            {
                var currentUser = httpContextAccessor.HttpContext?.User.Identities.FirstOrDefault(x => x.IsAuthenticated)?.Name;
                if (currentUser == null)
                {
                    createTicketResult.ErrorMessage = "User not found";
                    return createTicketResult;
                }

                var priority = unitOfWork.Repository<Priority>().GetByIdAsync(request.PriorityId!.Value);

                var ticket = new Ticket
                {
                    Summary = request.Summary,
                    Description = request.Description,
                    ProductId = request.ProductId!.Value,
                    CategoryId = request.CategoryId!.Value,
                    PriorityId = request.PriorityId!.Value,
                    AssignedToId = request.AssignedToId,
                    RaisedDate = DateTime.Now,
                    RaisedBy = currentUser,
                    Status = Constants.STATUS_NEW,
                    ExpectedDate = priority != null ? DateTime.Now.AddDays(priority.ExpectedDays) : DateTime.Now.AddDays(3)
                };

                unitOfWork.TicketRepository.Add(ticket);

                if (request.Files != null && request.Files.Count > 0)
                {
                    foreach (var file in request.Files)
                    {
                        var fileName = $"{Path.GetFileNameWithoutExtension(file.Name)}_{DateTime.Now:yyyyMMddHHmmss}{Path.GetExtension(file.Name)}";
                        var filePath = Path.Combine(uploadPath, fileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.OpenReadStream().CopyToAsync(fileStream);
                        }

                        var attachment = new Attachment
                        {
                            Ticket = ticket,
                            FileName = Path.GetFileName(file.Name),
                            ServerFileName = fileName,
                            FileSize = file.Size,
                            TicketId = ticket.TicketId
                        };
                        unitOfWork.Repository<Attachment>().Add(attachment);
                    }
                }

                var result = await unitOfWork.SaveChangesAsync() > 0;

                if (!result)
                {
                    createTicketResult.ErrorMessage = "Failed to create ticket";
                    return createTicketResult;
                }

                createTicketResult.IsSuccess = true;
                createTicketResult.Value = ticket.TicketId;
                return createTicketResult;
            }
            catch (Exception ex)
            {
                createTicketResult.ErrorMessage = "Failed: " + ex.Message;
                return createTicketResult;
            }
        }

        public GetTicketResponse FindTicket(int ticketId)
        {
            var result = unitOfWork.Repository<Ticket>().GetByIdAsync(ticketId);
            if (result is null) throw new Exception("Ticket not found");

            var attachments = unitOfWork.Repository<Attachment>().ListAll().Where(x => x.TicketId == result.TicketId);
            var attachmentPath = Path.Combine("uploads", "attachments");
            
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
                Attachments = attachments.Select(x => new AttachmentResponse
                (
                    FileName: x.FileName, 
                    ServerFileName: Path.Combine(attachmentPath, x.ServerFileName)
                )).ToList()
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

        public List<ChartResponse> GetSummary()
        {
            return unitOfWork.TicketRepository.GetSummary();
        }

        public List<ChartResponse> GetLastYearsTickets()
        {
            return unitOfWork.TicketRepository.GetLastYearsTickets();
        }

        public List<ChartResponse> ChartByCategory(string category)
        {
            return unitOfWork.TicketRepository.ChartByCategory(category);
        }
    }
}
