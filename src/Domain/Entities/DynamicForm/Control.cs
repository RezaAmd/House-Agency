using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Control
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string? Placeholder { get; set; }
        public FieldType Type { get; set; }
        public int DisplayOrder { get; set; }
        public string? JsonOption { get; set; }
        public bool IsRequired { get; set; }
    }
}