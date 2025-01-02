using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTO.Request
{
    public class CreateTicketRequest
    {
        [Required] public string Summary { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required] public int ProductId { get; set; }
        [Required] public int CategoryId { get; set; }
        [Required] public int PriorityId { get; set; }
        [Required] public string? AssignedToId { get; set; }
        public IList<IBrowserFile> Files { get; set; } = new List<IBrowserFile>();
    }
}
