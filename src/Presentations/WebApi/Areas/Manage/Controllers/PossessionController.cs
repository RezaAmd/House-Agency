using Application.Extentions;
using Application.Models;
using Application.Models.Possession;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Areas.Manage.Controllers
{
    [ApiController]
    [Area("manage")]
    [Route("[area]/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PossessionController : ControllerBase
    {
        #region Dependency Injection
        private readonly IPossessionService possessionService;

        public PossessionController(IPossessionService _possessionService)
        {
            possessionService = _possessionService;
        }
        #endregion

        [HttpPost]
        [ModelStateValidator]
        public async Task<ApiResult<object>> Entrust([FromBody] PossessionDto model)
        {
            string? userId = User.GetCurrentUserId();
            if (!string.IsNullOrEmpty(userId))
            {
                var newPossession = new Possession(model.Base.title, model.Base.meter, model.Base.Type, model.Base.TransactionType,
                    userId, DateTime.Now.AddYears(-5));
                var createNewPossessionResult = await possessionService.CreateAsync(newPossession);
                if (createNewPossessionResult.Succeeded)
                {
                    return Ok(newPossession.Id);
                }
                else
                {
                    return BadRequest(createNewPossessionResult.Errors);
                }
            }
            return Ok(model);
        }
    }
}