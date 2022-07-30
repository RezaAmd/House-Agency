using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Control : BaseEntity
{
    #region Constructors
    Control() { }
    public Control(string name, string label, string? placeholder = null,
        FieldType type = FieldType.Text, string? jsonOption = null, bool isRequired = false,
        long? min = null, long? max = null)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Label = label;
        Placeholder = placeholder;
        Type = type;
        JsonOption = jsonOption;
        IsRequired = isRequired;
        Min = min;
        Max = max;
    }
    #endregion

#nullable disable
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Label { get; set; }
#nullable enable
    public string? Placeholder { get; set; }
    public string? JsonOption { get; set; }
#nullable disable
    public FieldType Type { get; set; }
    public long? Min { get; set; } // Minimum length - Minimum number.
    public long? Max { get; set; } // Maximum length - Maximum number.
    public bool IsRequired { get; set; }

    public virtual ICollection<FormControl> FormControls { get; set; }
}