using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Areas.Manage.Controllers
{
    [ApiController]
    [Area("Manage")]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        #region Constructor
        public UserController()
        {

        }
        #endregion

        [HttpGet]
        public ApiResult<object> GetAll(string search, int page = 1)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public ApiResult<object> Get(string id)
        {

            return NotFound();
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

        [HttpDelete]
        public ApiResult<object> Delete()
        {
            return Ok();
        }
    }
}