using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Dynamic_Form
{
    public class FormControl
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Placeholder { get; set; }
        public bool IsRequired { get; set; }

        [ForeignKey("Form")]
        public string FormId { get; set; }
        public virtual Form Form { get; set; }

        [ForeignKey("Control")]
        public string ControlId { get; set; }
        public virtual FieldSignature FieldType { get; set; }
    }
}