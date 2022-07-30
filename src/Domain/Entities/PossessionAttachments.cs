using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class PossessionAttachment
{
    #region Constructors
    PossessionAttachment() { }
    public PossessionAttachment(string attachmentId, string possessionId)
    {
        Id = Guid.NewGuid().ToString();
        AttachmentId = attachmentId;
        PossessionId = possessionId;
    }
    #endregion
    public string Id { get; set; }
    [ForeignKey("Attachment")]
    public string AttachmentId { get; set; }
    public virtual Attachment Attachment { get; set; }

    [ForeignKey("Possession")]
    public string PossessionId { get; set; }
    public virtual Possession Possession { get; set; }
}