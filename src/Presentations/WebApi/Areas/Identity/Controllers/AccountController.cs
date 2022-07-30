using Application.Extensions;
using Application.Models;
using Application.Repositories.Users;
using Application.Services.Identities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Identity.Models;

namespace WebApi.Areas.Identity.Controllers;

[ApiController]
[Area("Identity")]
[Route("[area]/[controller]/[action]")]
[Authorize]
public class AccountController : ControllerBase
{
    #region DI & Ctor's
    private readonly IUserRepository userService;
    private readonly ISignInService signInService;

    public AccountController(ISignInService _signinService,
        IUserRepository _userService)
    {
        signInService = _signinService;
        userService = _userService;
    }
    #endregion

    [HttpPost]
    [AllowAnonymous]
    [Route("/[area]/[action]")]
    public async Task<ApiResult<object>> SignIn([FromBody] SignInDto signInParam)
    {

        if (!string.IsNullOrEmpty(signInParam.RefreshToken))
        {
            //var claims = signInService.ReadToken(signInParam.RefreshToken);
            //string userId = claims.FirstOrDefault(x => x.ValueType == ClaimTypes.NameIdentifier).Value;

            var user = await userService.FindByIdentityAsync("admin",
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
                #region Jwt Token
                var expireDateTime = DateTime.Now.AddMinutes(30);
                var JwtBearer = signInService.GenerateJwtToken(user, expireDateTime);
                #endregion

                #region Refresh Token
                var refreshTokenExpireDateTime = DateTime.Now.AddHours(1);
                var RefreshJwtBearer = signInService.GenerateJwtToken(user, expireDateTime);
                #endregion

                if (JwtBearer.Status.Succeeded)
                {
                    result.Token = JwtBearer.Token;
                    result.ExpireDate = expireDateTime.ToString("yyyy/MM/dd HH:mm:ss");

                    result.RefreshToken = RefreshJwtBearer.Token;
                    result.RefreshTokenExpireDate = refreshTokenExpireDateTime.ToString("yyyy/MM/dd HH:mm:ss");

                    return Ok(result);
                }
            }

            return BadRequest();
        }
        // Signin with username and password.
        else if (!string.IsNullOrEmpty(signInParam.Username) && !string.IsNullOrEmpty(signInParam.Password))
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
                    var expireDateTime = DateTime.Now.AddMinutes(30);
                    var JwtBearer = signInService.GenerateJwtToken(user, expireDateTime);
                    #endregion

                    #region Refresh Token
                    var refreshTokenExpireDateTime = DateTime.Now.AddHours(1);
                    var RefreshJwtBearer = signInService.GenerateJwtToken(user, expireDateTime);
                    #endregion

                    if (JwtBearer.Status.Succeeded)
                    {
                        result.Token = JwtBearer.Token;
                        result.ExpireDate = expireDateTime.ToString("yyyy/MM/dd HH:mm:ss");

                        result.RefreshToken = RefreshJwtBearer.Token;
                        result.RefreshTokenExpireDate = refreshTokenExpireDateTime.ToString("yyyy/MM/dd HH:mm:ss");

                        return Ok(result);
                    }
                }
            }
            return BadRequest("نام کاربری یا رمز ورود اشتباه است.");
        }
        else
        {
            return BadRequest("نام کاربری و رمز عبور را وارد نکردید.");
        }
    }

    [HttpGet]
    public async Task<ApiResult<object>> Info()
    {
        string? currentUserId = User.GetCurrentUserId();
        if (currentUserId != null)
        {
            var user = await userService.FindByIdAsync(currentUserId);
            if (user != null)
            {

                return Ok(user);
            }
            return NotFound();
        }
        return BadRequest();
    }

    [HttpPatch]
    public async Task<ApiResult<object>> Update([FromBody] UpdateProfileDto model)
    {
        string? currentUserId = User.GetCurrentUserId();
        if (currentUserId != null)
        {
            var user = await userService.FindByIdAsync(currentUserId);
            if (user != null)
            {
                if (user.Name != model.Name)
                {
                    user.Name = model.Name;
                }
                if (user.Surname != model.Surname)
                {
                    user.Surname = model.Surname;
                }
                if (user.Email != model.Email)
                {
                    user.Email = model.Email;
                    user.EmailConfirmed = false;
                }
                if (user.PhoneNumber != model.PhoneNumber)
                {
                    user.PhoneNumber = model.PhoneNumber;
                    user.PhoneNumberConfirmed = false;
                }
                var updateUserResult = await userService.UpdateAsync(user);
                if (updateUserResult.Succeeded)
                    return Ok(user);
                return BadRequest(updateUserResult.Errors);
            }
            return NotFound("User not found!");
        }
        return NotFound("Current user id not found!");
    }
}