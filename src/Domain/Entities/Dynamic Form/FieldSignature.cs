using Domain.Enums.Dynamic_Form;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Dynamic_Form
{
    public class FieldSignature
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string RegEx { get; set; }
        public ControlSignatureType Type { get; set; }
    }
}