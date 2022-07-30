using Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class FormControlData : BaseEntity
{
    [Key]
    public string Id { get; set; }
    public string Value { get; set; }

    [ForeignKey("Possession")]
    public string PossessionId { get; set; }
    public virtual Possession Possession { get; set; }

    [ForeignKey("FormControl")]
    public string FormControlId { get; set; }
    public virtual FormControl FormControl { get; set; }

    [ForeignKey("User")]
    public string UserId { get; set; }
    public virtual User User { get; set; }
}