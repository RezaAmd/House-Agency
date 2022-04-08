﻿using Application.Dao;
using Application.Extentions;
using Application.Models;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Manage.Models;

namespace WebApi.Areas.Manage.Controllers
{
    [ApiController]
    [Area("Manage")]
    [Route("[controller]/[action]")]
    public class RoleController : ControllerBase
    {
        #region Constructor
        private readonly IRoleService roleService;

        public RoleController(IRoleService _roleService)
        {
            roleService = _roleService;
        }
        #endregion

        [HttpGet]
        //[Authorize(Roles = "ReadRole")]
        public async Task<ApiResult<object>> GetAll(string keyword, int page = 1, CancellationToken cancellationToken = new())
        {
            int pageSize = 30;
            var roles = await roleService.GetAllAsync(keyword, page, pageSize, cancellationToken);
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
            var result = await roleService.CreateAsync(newRole, cancellationToken);
            if (result.Succeeded)
                return Ok(newRole.Id);
            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "DeleteRole")]
        public async Task<ApiResult<object>> Delete([FromRoute] string id, CancellationToken cancellationToken = new())
        {
            var role = await roleService.FindByIdAsync(id);
            if (role != null)
            {
                var deleteResult = await roleService.DeleteAsync(role, cancellationToken);
                if (deleteResult.Succeeded)
                    return Ok($"مجوز {role.Name} با موفقیت حذف شد.");
                return BadRequest(deleteResult.Errors);
            }
            return NotFound("مجوز مورد نظر پیدا نشد.");
        }
    }
}