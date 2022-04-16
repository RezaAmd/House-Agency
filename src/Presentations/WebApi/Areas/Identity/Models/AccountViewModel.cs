namespace WebApi.Areas.Identity.Models
{
    public class SignInVM
    {
        public SignInVM()
        {
        }
        public SignInVM(string token, string expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }

        public string Token { get; set; }
        public string ExpireDate { get; set; }
        public string RefreshToken { get; set; }
        public string RefreshTokenExpireDate { get; set; }
        public UserThumbailDetailVM User { get; set; }

    }

    public class UserThumbailDetailVM
    {
        public string username { get; set; }
#nullable enable
        public string? name { get; set; }
        public string? surname { get; set; }
#nullable disable
        public List<string> roles { get; set; }
    }
}