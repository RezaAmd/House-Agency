using Domain.Entities.Identity;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Possession
    {
        #region Constructors
        public Possession()
        {

        }
        #endregion

        public string Id { get; set; }
        public string Title { get; set; }
        public int Meter { get; set; }
        public DateTime? ConstructionDateTime { get; set; } //
        public string? Description { get; set; }
        public PossessionType Type { get; set; }
        public TransactionType TransactionType { get; set; }
        public PossessionState State { get; set; }

        [ForeignKey("PublishedBy")]
        public string PublishedById { get; set; }
        public virtual User PublishedBy { get; set; }
        public DateTime PublishedDateTime { get; set; }


        [ForeignKey("Adviser")]
        public string? AdviserId { get; set; }
        public virtual User Adviser { get; set; }

        [ForeignKey("Location")]
        public long RegionId { get; set; }
        public virtual Region Region { get; set; }

        public virtual ICollection<PossessionAttachments> PossessionAttachments { get; set; }
    }
}
