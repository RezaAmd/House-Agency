using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Form : BaseEntity
{
    #region Constructors
    Form() { }

    public Form(string name, string title = null)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Title = title;
        CreatedDateTime = DateTime.Now;
    }
    #endregion

    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDateTime { get; set; }

    public virtual ICollection<FormControl> FormControls { get; set; }
}