﻿using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using Infrastructure.Common;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Hosting;

namespace Infrastructure.Services
{
    public class TicketService(
        IUnitOfWork unitOfWork, 
        IWebHostEnvironment webHostEnvironment, 
        IUserUtility userUtility) : ITicketService
    {
        public async Task<BaseResponse<int>> CreateTicket(CreateTicketRequest request)
        {
            var createTicketResult = new BaseResponse<int> { IsSuccess = false };
            var uploadPath = Path.Combine(webHostEnvironment.WebRootPath, "uploads", "attachments");

            try
            {
                User? currentUser = await userUtility.GetCurrentUserAsync();
                if (currentUser?.Email == null)
                {
                    createTicketResult.ErrorMessage = "User not found";
                    return createTicketResult;
                }

                var priority = await unitOfWork.Repository<Priority>().GetByIdAsync(request.PriorityId);

                var ticket = new Ticket
                {
                    Summary = request.Summary,
                    Description = request.Description,
                    ProductId = request.ProductId,
                    CategoryId = request.CategoryId,
                    PriorityId = request.PriorityId,
                    AssignedToId = request.AssignedToId,
                    RaisedDate = DateTime.Now,
                    RaisedBy = currentUser?.Id,
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
                            CreatedDate = DateTime.Now
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
            var result = unitOfWork.TicketRepository.FindTicket(ticketId);
            if (result is null) throw new TicketNotFoundException("Ticket not found");

            var attachmentPath = Path.Combine("uploads", "attachments");

            return new GetTicketResponse
            {
                TicketId = result.TicketId,
                Summary = result.Summary ?? string.Empty,
                Description = result.Description ?? string.Empty,
                ProductId = result.ProductId,
                CategoryId = result.CategoryId,
                PriorityId = result.PriorityId,
                Status = result.Status ?? string.Empty,
                AssignedToId = result.AssignedToId ?? string.Empty,
                RaisedBy = result.User?.Id ?? string.Empty,
                RaisedByName = result.User?.Email ?? string.Empty,
                RaisedByAvatar = result.User?.Avatar ?? string.Empty,
                CreatedDate = result.RaisedDate,
                ExpectedDate = result.ExpectedDate,
                ClosedBy = result.ClosedBy ?? string.Empty,
                ClosedDate = result.ClosedDate,
                Attachments = result.Attachments.Select(x => new AttachmentResponse
                (
                    FileName: x.FileName ?? string.Empty,
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
                Summary = x.Summary ?? string.Empty,
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

            var currentTicket = await unitOfWork.Repository<Ticket>().GetByIdAsync(request.TicketId);
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
                User? currentUser = await userUtility.GetCurrentUserAsync();

                if (currentUser?.Email == null)
                {
                    result.ErrorMessage = "User not found";
                    return result;
                }
                currentTicket.ClosedBy = currentUser?.Email;
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
