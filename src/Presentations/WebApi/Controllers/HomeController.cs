using Application.Models;
using Application.Models.Possession;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        #region Dependency Injection


        #endregion

        [HttpPost]
        public async Task<ApiResult<object>> Entrust([FromBody] PossessionDto model)
        {
            return Ok(model);
        }
    }
}