using System.ComponentModel.DataAnnotations;

namespace WebApi.Areas.Identity.Models
{
    public class SignInDto
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string RefreshToken { get; set; }
    }

    public class UpdateProfileDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }

        [Phone(ErrorMessage = "یک شماره موبایل صحیح وارد کنید.")]
        [StringLength(100, ErrorMessage = "شماره موبایل باید 11 رقم باشد و با 0 شروع شود.")]
        [Required(ErrorMessage = "شماره موبایل خود را وارد کنید.")]
        public string PhoneNumber { get; set; }
    }
}
