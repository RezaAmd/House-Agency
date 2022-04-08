using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Areas.Manage.Controllers
{
    [ApiController]
    [Area("Manage")]
    [Route("[controller]/[action]")]
    public class RoleController : ControllerBase
    {
        #region Constructor
        public RoleController()
        {

        }
        #endregion

        [HttpGet]
        public ApiResult<object> GetAll(string search, int page = 1)
        {
            return Ok();
        }

        [HttpPost]
        public ApiResult<object> Create()
        {
            return Ok();
        }

        [HttpPost]
        public ApiResult<object> Edit()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ApiResult<object> Delete(string id)
        {
            return Ok();
        }
    }
}