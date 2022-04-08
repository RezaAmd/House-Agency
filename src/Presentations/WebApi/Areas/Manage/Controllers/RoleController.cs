using Application.Models;
using Microsoft.AspNetCore.Http;
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

        public ApiResult<object> GetAll(string search, int page = 1)
        {
            return Ok();
        }

        public ApiResult<object> Create()
        {
            return Ok();
        }

        public ApiResult<object> Edit()
        {
            return Ok();
        }

        public ApiResult<object> Delete()
        {
            return Ok();
        }
    }
}