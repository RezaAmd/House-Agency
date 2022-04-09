namespace WebApi.Areas.Identity.Models
{
    public class SignInVM
    {
        public SignInVM(string token, string expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }
        public string Token { get; set; }
        public string ExpireDate { get; set; }
    }
}