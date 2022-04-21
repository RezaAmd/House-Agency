using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Region
    {
        #region Constructors
        public Region(string name, LocationType type = LocationType.Province)
        {
            Name = name;
            Type = type;
        }
        #endregion

        public long Id { get; set; }
        public string Name { get; set; }
        public LocationType Type { get; set; }

        [ForeignKey("Parent")]
        public long ParentId { get; set; }
        public virtual Region Parent { get; set; }
    }
}