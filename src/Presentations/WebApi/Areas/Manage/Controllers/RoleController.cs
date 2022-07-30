using Application.Extensions;
using Application.Models;
using Application.Repositories.Roles;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Manage.Models;

namespace WebApi.Areas.Manage.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Area("Manage")]
    [Route("[area]/[controller]/[action]")]
    public class RoleController : ControllerBase
    {
        #region Dependency Injection
        private readonly IRoleRepository roleService;

        public RoleController(IRoleRepository _roleService)
        {
            roleService = _roleService;
        }
        #endregion

        [HttpGet]
        //[Authorize(Roles = "ReadRole")]
        public async Task<ApiResult<object>> GetAll([FromQuery] string? keyword, [FromQuery] PaginationParameter pagination = default,
            CancellationToken cancellationToken = new())
        {
            int pageSize = 10;
            var roles = await roleService.GetAllAsync<RoleThumbailMVM>(keyword, pagination.Page, pageSize, cancellationToken);
            if (roles.items.Count > 0)
                return Ok(roles);
            return NotFound(roles);
        }

        [HttpPost]
        [ModelStateValidator]
        //[Authorize(Roles = "CreateRole")]
        public async Task<ApiResult<object>> Create([FromBody] CreateRoleMDto model, CancellationToken cancellationToken = new())
        {
            var newRole = new Role(model.Name, model.Title, model.Description);
            var result = await roleService.AddAsync(newRole, true, cancellationToken);
            if (result)
                return Ok(new CreateRoleMVM(newRole.Id));
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ApiResult<object> Edit([FromRoute] string id, string name)
        {
            return Ok((id, name));
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "DeleteRole")]
        public async Task<ApiResult<object>> Delete([FromRoute] string id, CancellationToken cancellationToken = new())
        {
            try
            {
                var role = await roleService.FindByIdAsync(cancellationToken, id);
                if (role != null)
                {
                    var deleteResult = await roleService.DeleteAsync(role, true, cancellationToken);
                    if (deleteResult)
                        return Ok($"مجوز {role.Name} با موفقیت حذف شد.");
                    return BadRequest(deleteResult);
                }
                return NotFound("مجوز مورد نظر پیدا نشد.");
            }
            catch (Exception ex)
            {
                return BadRequest("درخواست با خطا مواجه شد.");
                throw;
            }
        }
    }
}