using Application.Dao;
using Application.Interfaces.Identity;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Identity.Models;

namespace WebApi.Areas.Identity.Controllers
{
    [ApiController]
    [Area("Identity")]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        #region Initialize
        private readonly IUserService userService;
        private readonly ISignInService signInService;

        public AccountController(ISignInService _signinService,
            IUserService _userService)
        {
            signInService = _signinService;
            userService = _userService;
        }
        #endregion

        [HttpPost]
        public async Task<ApiResult<object>> SignIn([FromBody] SignInDto signInParam)
        {
            var user = await userService.FindByIdentityAsync(signInParam.Username,
                asNoTracking: false, withRoles: true, withPermissions: true);
            if (user != null)
            {
                var passwordValidation = userService.CheckPassword(user, signInParam.Password);
                if (passwordValidation)
                {
                    var JwtBearer = signInService.GenerateJwtToken(user, DateTime.Now.AddHours(3));
                    if (JwtBearer.Status.Succeeded)
                        return Ok(new SignInVM(JwtBearer.Token));
                }
            }
            return BadRequest("نام کاربری یا رمز ورود اشتباه است.");
        }
    }
}