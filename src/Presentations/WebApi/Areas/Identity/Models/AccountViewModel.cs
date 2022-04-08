namespace WebApi.Areas.Identity.Models
{
    public class SignInVM
    {
        public SignInVM(string token)
        {
            Token = token;
        }
        public string Token { get; set; }
    }
}