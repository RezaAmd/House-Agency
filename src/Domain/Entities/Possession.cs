using Domain.Entities.Identity;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Possession : BaseEntity
    {
#nullable disable
        #region Constructors
        Possession() { }

        public Possession(string title, int meter, PossessionType type, TransactionType transactionType,
            string createdBy, DateTime? constructionDate)
        {
            Title = title;
            Meter = meter;
            Type = type;
            TransactionType = transactionType;
            ConstructionDate = constructionDate;
            CreatedBy = createdBy;
            CreatedDateTime = DateTime.Now;
        }
        #endregion

        public string Id { get; set; }
        public string Title { get; set; }
        public int Meter { get; set; }
        public DateTime? ConstructionDate { get; set; } //
        public string? Description { get; set; }
        public PossessionType Type { get; set; }
        public TransactionType TransactionType { get; set; }
        public PossessionState State { get; set; }

        [ForeignKey("PublishedBy")]
        public string CreatedBy { get; set; }
        public virtual User PublishedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }


        [ForeignKey("Adviser")]
        public string? AdviserId { get; set; }
        public virtual User Adviser { get; set; }

        [ForeignKey("Location")]
        public long RegionId { get; set; }
        public virtual Region Region { get; set; }

        public virtual ICollection<PossessionAttachments> PossessionAttachments { get; set; }
    }
}
