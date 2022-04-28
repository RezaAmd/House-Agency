using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Control : BaseEntity
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string? Placeholder { get; set; }
        public FieldType Type { get; set; }
        public int Priority { get; set; } // order by this for priority.
        public long Min { get; set; } // Minimum length - Minimum number.
        public long Max { get; set; } // Maximum length - Maximum number.
        public string? JsonOption { get; set; }
        public bool IsRequired { get; set; }
    }
}