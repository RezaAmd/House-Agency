using Application.Dao;
using Application.Models;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Manage.Models;

namespace WebApi.Areas.Manage.Controllers
{
    [ApiController]
    [Area("Manage")]
    [Route("[area]/[controller]/[action]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        #region Constructor
        private readonly IUserService userService;
        private readonly IPermissionService permissionService;
        private readonly ILogger<UserController> logger;

        public UserController(IUserService _userService,
            IPermissionService _permissionService,
            ILogger<UserController> _logger)
        {
            userService = _userService;
            logger = _logger;
            permissionService = _permissionService;

        }
        #endregion

        [HttpGet]
        public async Task<ApiResult<object>> GetAll([FromQuery] string? keyword = null, int page = 1, CancellationToken cancellationToken = new())
        {
            int pageSize = 4;
            var users = await userService.GetAllAsync<UserThumbailMVM>(keyword: keyword, page: page, pageSize: pageSize, cancellationToken: cancellationToken);
            if (users.totalCount > 0)
                return Ok(users);
            return NotFound(users);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<object>> Get([FromRoute] string id)
        {
            var user = await userService.FindByIdAsync(id);
            if (user != null)
                return Ok(new UserInfoMVM(user.Id, user.Username, user.PhoneNumber, user.JoinedDate, user.Email, user.Name, user.Surname));
            return NotFound("کاربر مورد نظر یافت نشد.");
        }

        [HttpPost]
        //[Authorize(Roles = "CreateUser")]
        public async Task<ApiResult<object>> Create([FromBody] CreateUserMDto model, CancellationToken cancellationToken = new CancellationToken())
        {
            #region Create user
            // Create new user.
            var newUser = new User(model.username, model.phoneNumber, model.email,
                model.name, model.surname, false, false);
            var createUserResult = await userService.CreateAsync(newUser, model.password, cancellationToken);
            if (createUserResult.Succeeded)
            {
                return Ok(new CreateUserMVM(newUser.Id));
            }
            #endregion

            logger.LogError("Failed to create new user.");
            return BadRequest(createUserResult.Errors);
        }

        [HttpPost]
        //[Authorize(Roles = "UpdateUser")]
        public async Task<ApiResult<object>> Edit([FromRoute] string id, [FromBody] EditUserMDto model, CancellationToken cancellationToken)
        {
            var user = await userService.FindByIdAsync(id);
            if (user != null)
            {
                bool hasChanged = false;

                #region Validate
                if (model.username.ToLower() != user.Username.ToLower())
                {
                    hasChanged = true;
                    user.Username = model.username;
                }

                if (model.phoneNumber.ToLower() != user.PhoneNumber.ToLower())
                {
                    hasChanged = true;
                    user.PhoneNumber = model.phoneNumber;
                }

                if (model.email.ToLower() != user.Email.ToLower())
                {
                    hasChanged = true;
                    user.Email = model.email;
                }

                if (model.name.ToLower() != user.Name.ToLower())
                {
                    hasChanged = true;
                    user.Name = model.name;
                }

                if (model.surname.ToLower() != user.Surname.ToLower())
                {
                    hasChanged = true;
                    user.Surname = model.surname;
                }
                #endregion

                if (hasChanged)
                {
                    var updateResult = await userService.UpdateAsync(user, cancellationToken);
                    if (updateResult.Succeeded)
                        return Ok();
                    return BadRequest(updateResult.Errors);
                }
                return BadRequest("هیچ تغییراتی صورت نگرفته است!");
            }
            return NotFound("کاربر مورد نظر پیدا نشد.");
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult<object>> Delete([FromRoute] string id, CancellationToken cancellationToken)
        {
            var user = await userService.FindByIdAsync(id);
            if (user != null)
            {
                var deleteResult = await userService.DeleteAsync(user, cancellationToken);
                if (deleteResult.Succeeded)
                    return Ok("کاربر " + user.Username + " با موفقیت حذف گردید.");
                return BadRequest(deleteResult.Errors);
            }
            return NotFound("کاربر مورد نظر پیدا نشد.");
        }
    }
}