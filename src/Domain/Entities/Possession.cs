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
        public DateTime? ConstructionDateTime { get; set; }
        public string? Description { get; set; }
        public bool IsAvailable { get; set; }
        public PossessionState state { get; set; }

        public DateTime PublishedDateTime { get; set; }

        [ForeignKey("PublishedBy")]
        public string PublishedById { get; set; }
        public virtual User PublishedBy { get; set; }

        [ForeignKey("Adviser")]
        public string? AdviserId { get; set; }
        public virtual User Adviser { get; set; }

        [ForeignKey("Location")]
        public long RegionId { get; set; }
        public virtual Region Region { get; set; }

        public virtual ICollection<PossessionAttachments> PossessionAttachments { get; set; }
    }
}
