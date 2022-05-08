using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Areas.Manage.Controllers
{
    [ApiController]
    [Area("Manage")]
    [Route("[area]/[controller]/[action]")]
    public class MediaController : ControllerBase
    {
        #region Dependency Injection

        #endregion

        [HttpPost]
        public async Task<ApiResult<object>> Upload([FromForm] List<IFormFile> Files)
        {

            return Ok(Files.Sum(file => file.Length));
        }
    }
}