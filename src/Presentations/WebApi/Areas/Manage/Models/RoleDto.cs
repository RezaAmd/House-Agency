using System.ComponentModel.DataAnnotations;

namespace WebApi.Areas.Manage.Models
{
    public class CreateRoleMDto
    {
        [Required(ErrorMessage = "وارد کردن نام نقش ضروری است.")]
        public string Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
