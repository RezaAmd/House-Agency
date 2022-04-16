using Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Possession
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Meter { get; set; }
        public string? Description { get; set; }
        public bool IsAvailable { get; set; }

        [ForeignKey("User")]
        public string OwnerId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Location")]
        public long LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
