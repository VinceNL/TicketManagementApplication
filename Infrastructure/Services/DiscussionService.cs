using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using Microsoft.AspNetCore.Hosting;

namespace Infrastructure.Services
{
    public class DiscussionService(
        IUnitOfWork unitOfWork,
        IAccountService accountService,
        IDiscussionRepository discussionsRepository,
        IWebHostEnvironment webHostEnvironment) : IDiscussionService
    {
        public async Task<BaseResponse> Create(CreateDiscussionRequest request)
        {
            BaseResponse response = new();
            response.IsSuccess = false;

            var uploadPath = Path.Combine(webHostEnvironment.WebRootPath, "uploads", "attachments");

            var currentUser = await accountService.GetCurrentUserAsync();
            if (!currentUser.IsSuccess)
            {
                response.ErrorMessage = currentUser.ErrorMessage;
                return response;
            }

            Discussion discussion = new()
            {
                TicketId = request.TicketId,
                Message = request.Message,
                UserId = currentUser.Value.Id,
                CreatedDate = DateTime.Now
            };

            unitOfWork.DiscussionRepository.Add(discussion);

            if (request.Attachments != null && request.Attachments.Count > 0)
            {
                foreach (var file in request.Attachments)
                {
                    var fileName = $"{Path.GetFileNameWithoutExtension(file.Name)}_{DateTime.Now:yyyyMMddHHmmss}{Path.GetExtension(file.Name)}";
                    var filePath = Path.Combine(uploadPath, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.OpenReadStream().CopyToAsync(fileStream);
                    }

                    var attachment = new Attachment
                    {
                        Discussion = discussion,
                        FileName = Path.GetFileName(file.Name),
                        ServerFileName = fileName,
                        FileSize = file.Size,
                        CreatedDate = DateTime.Now
                    };
                    unitOfWork.Repository<Attachment>().Add(attachment);
                }
            }

            var result = await unitOfWork.SaveChangesAsync() > 0;

            if (result)
            {
                response.IsSuccess = true;
                return response;
            }
            else
            {
                response.ErrorMessage = "Failed to create discussion";
                return response;
            }
        }

        public List<DiscussionResponse> GetDiscussions(int ticketId)
        {
            var uploadPath = Path.Combine("uploads", "attachments");
            var result = discussionsRepository.GetDiscussions(ticketId);

            return result.Select(x => new DiscussionResponse
            {
                Message = x.Message ?? string.Empty,
                CreatedDate = x.CreatedDate,
                User = x.User,
                Attachments = x.Attachments.Select(a => new AttachmentResponse(
                    a.FileName ?? string.Empty,
                    Path.Combine(uploadPath, a.ServerFileName)
                )).ToList()
            }).ToList();
        }
    }
}
