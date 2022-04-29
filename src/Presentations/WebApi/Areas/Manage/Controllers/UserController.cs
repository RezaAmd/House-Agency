using Application.Dao;
using Application.Extentions;
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
        //[Authorize(Roles = "ReadUser")]
        public async Task<ApiResult<object>> GetAll([FromQuery] string? keyword = null, [FromQuery] PaginationParameter pagination = default,
            CancellationToken cancellationToken = new())
        {
            int pageSize = 10;
            try
            {
                var users = await userService.GetAllAsync<UserThumbailMVM>(keyword: keyword, page: pagination.Page, pageSize: pageSize, cancellationToken: cancellationToken);
                if (users.totalCount > 0)
                    return Ok(users);
                return NotFound(users);

            }
            catch (Exception ex)
            {

                throw;
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "ReadUser")]
        public async Task<ApiResult<object>> Get([FromRoute] string id, CancellationToken cancellationToken = new())
        {
            var user = await userService.FindByIdAsync(id, withRoles: true, cancellationToken: cancellationToken);
            if (user != null)
            {
                var result = new UserInfoMVM(user.Id, user.Username, user.PhoneNumber, user.CreatedDateTime,
                    user.Email, user.Name, user.Surname);

                result.Roles = new List<RoleThumbailMVM>();
                foreach (var userRole in user.UserRoles)
                {
                    result.Roles.Add(new RoleThumbailMVM(userRole.RoleId, userRole.Role.Name, userRole.Role.Title));
                }
                return Ok(result);
            }
            return NotFound("کاربر مورد نظر یافت نشد.");
        }

        [HttpPost]
        [ModelStateValidator]
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

        [HttpPost("{id}")]
        [ModelStateValidator]
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
        //[Authorize(Roles = "DeleteUser")]
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

        [HttpPatch("{id}")]
        //[Authorize(Roles = "AssignRoleToUser")]
        public async Task<ApiResult<object>> AssignRoles([FromRoute] string id, [FromBody] List<string> rolesId,
            CancellationToken cancellationToken)
        {
            if (rolesId.Count > 0)
            {

                var user = await userService.FindByIdAsync(id, withRoles: true, cancellationToken: cancellationToken);
                if (user != null)
                {
                    bool assigned = false;
                    foreach (var roleId in rolesId)
                    {
                        if (!user.UserRoles.Any(userRole => userRole.RoleId == roleId))
                        {
                            assigned = true;
                            user.UserRoles.Add(new UserRole(user.Id, roleId));
                        }
                    }
                    if (assigned)
                    {
                        var updateResult = await userService.UpdateAsync(user, cancellationToken);
                        if (updateResult.Succeeded)
                            return Ok($"نقش ها با موفقیت به کاربر '{user.Name}' اضافه شدند!");
                        return BadRequest("افزودن نقش با خطا مواجه شد.");
                    }
                    return Ok("هیچ نقشی به کاربر اضافه نشد. شاید نقش ها تکراری بودند!");
                }
                else
                    return NotFound("کاربر مورد نظر یافت نشد.");
            }
            return BadRequest("هیچ نقشی تعیین نشده.");
        }

        [HttpPatch("{id}")]
        //[Authorize(Roles = "AssignRoleToUser")]
        public async Task<ApiResult<object>> UnAssignRoles([FromRoute] string id, [FromBody] List<string> rolesId,
            CancellationToken cancellationToken)
        {
            if (rolesId.Count > 0)
            {
                var user = await userService.FindByIdAsync(id, withRoles: true, cancellationToken: cancellationToken);
                if (user != null)
                {
                    bool removedAnyRole = false;
                    foreach (var roleId in rolesId)
                    {
                        var userRole = user.UserRoles.FirstOrDefault(ur => ur.RoleId == roleId);
                        if (userRole != null)
                        {
                            removedAnyRole = true;
                            user.UserRoles.Remove(userRole);
                        }
                    }
                    if (removedAnyRole)
                    {
                        var updateResult = await userService.UpdateAsync(user, cancellationToken);
                        if (updateResult.Succeeded)
                            return Ok($"نقش ها با موفقیت از کاربر '{user.Name}' حذف شدند.");
                    }
                    else
                        return NotFound("نقش های انتخاب شده، به کاربر مرتبط نیستند!");
                }
                return NotFound();
            }
            return BadRequest("هیچ نقشی تعیین نشده.");
        }
    }
}