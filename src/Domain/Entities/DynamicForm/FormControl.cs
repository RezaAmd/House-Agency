using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class FormControl
    {
        [ForeignKey("Form")]
        public string FormId { get; set; }
        public Form Form { get; set; }

        [ForeignKey("Control")]
        public string ControlId { get; set; }
        public Control Control { get; set; }
    }
}