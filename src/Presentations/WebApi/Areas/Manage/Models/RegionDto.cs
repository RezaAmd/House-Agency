using System.ComponentModel.DataAnnotations;

namespace WebApi.Areas.Manage.Models
{
    public class CreateRegionDto
    {
        [Required(ErrorMessage = "وارد کردن نام ضروری است.")]
        [StringLength(20, ErrorMessage = "حداقل 3 و حداکثر 20 کارکتر وارد کنید.", MinimumLength = 3)]
        public string Name { get; set; }
        public long? ParentId { get; set; }
    }
}
