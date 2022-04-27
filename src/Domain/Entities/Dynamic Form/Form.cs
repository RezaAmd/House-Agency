using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Dynamic_Form
{
    public class Form
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
    }
}