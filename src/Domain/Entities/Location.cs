using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Location
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public LocationType Type { get; set; }

        [ForeignKey("Parent")]
        public long ParentId { get; set; }
        public virtual Location Parent { get; set; }
    }
}