using Application.Dao;
using Application.Interfaces.Identity;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Identity.Models;

namespace WebApi.Areas.Identity.Controllers
{
    [ApiController]
    [Area("Identity")]
    [Route("[area]/[controller]/[action]")]
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
        [Route("/[area]/[action]")]
        public async Task<ApiResult<object>> SignIn([FromBody] SignInDto signInParam)
        {
            var user = await userService.FindByIdentityAsync(signInParam.Username,
                asNoTracking: false, withRoles: true, withPermissions: true);
            if (user != null)
            {
                var result = new SignInVM();
                result.User = new UserThumbailDetailVM();
                result.User.username = user.Username;
                result.User.name = user.Name;
                result.User.surname = user.Surname;
                result.User.roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();
                #region map user

                #endregion
                var passwordValidation = userService.CheckPassword(user, signInParam.Password);
                if (passwordValidation)
                {
                    #region Jwt Token
                    var expireDateTime = DateTime.Now.AddHours(3);
                    var JwtBearer = signInService.GenerateJwtToken(user, expireDateTime);
                    #endregion

                    #region Refresh Token
                    var refreshTokenExpireDateTime = DateTime.Now.AddHours(3);
                    var RefreshJwtBearer = signInService.GenerateJwtToken(user, expireDateTime);
                    #endregion

                    if (JwtBearer.Status.Succeeded)
                    {
                        result.Token = JwtBearer.Token;
                        result.ExpireDate = expireDateTime.ToString("yyyy/MM/dd HH:mm:ss");

                        result.RefreshToken = RefreshJwtBearer.Token;
                        result.ExpireDate = refreshTokenExpireDateTime.ToString("yyyy/MM/dd HH:mm:ss");

                        return Ok(result);
                    }
                }
            }
            return BadRequest("نام کاربری یا رمز ورود اشتباه است.");
        }
    }
}