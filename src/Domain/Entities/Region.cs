using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Region : BaseEntity
{
    #region Constructors
    public Region(string name, RegionType type = RegionType.Province)
    {
        Name = name;
        Type = type;
    }
    #endregion

    [Key]
    public long Id { get; set; }
    public string Name { get; set; }
    public RegionType Type { get; set; }

    [ForeignKey("Parent")]
    public long? ParentId { get; set; }
    public virtual Region Parent { get; set; }

    public virtual ICollection<Region> Children { get; set; }
}