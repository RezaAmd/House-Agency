using Application.Models;
using Application.Models.Possession;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Areas.Manage.Controllers
{
    [ApiController]
    [Area("manage")]
    [Route("[area]/[controller]/[action]")]
    public class PossessionController : ControllerBase
    {

        [HttpPost]
        public ApiResult<object> Entrust([FromBody] PossessionDto model)
        {

            return Ok(model);
        }
    }
}
