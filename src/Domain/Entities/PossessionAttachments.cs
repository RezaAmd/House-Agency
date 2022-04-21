using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PossessionAttachments
    {
        public string Id { get; set; }
        [ForeignKey("Attachment")]
        public string AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }

        [ForeignKey("Possession")]
        public string PossessionId { get; set; }
        public virtual Possession Possession { get; set; }
    }
}