using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Attachment
    {
        public int AttachmentId { get; set; }
        public string? FileName { get; set; }
        public string ServerFileName { get; set; } = null!;
        public long FileSize { get; set; }
        public DateTime CreatedDate { get; set; }


        [ForeignKey(nameof(Ticket))]
        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;


        [ForeignKey(nameof(Discussion))]
        public int? DiscussionId { get; set; }
        public Discussion Discussion { get; set; } = null!;
    }
}
