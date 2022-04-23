using System.ComponentModel.DataAnnotations;

namespace WebApi.Areas.Manage.Models
{
    public class CreateRegionDto
    {
        [Required(ErrorMessage = "وارد کردن نام ضروری است.")]
        public string Name { get; set; }
        public long? ParentId { get; set; }
    }
}
