using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Dynamic_Form
{
    public class FormData
    {
        [Key]
        public string Id { get; set; }
        public string Value { get; set; }
    }
}