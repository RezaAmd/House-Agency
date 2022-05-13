using Application.Models;
using Application.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Areas.Manage.Controllers
{
    [ApiController]
    [Area("Manage")]
    [Route("[area]/[controller]/[action]")]
    public class FileController : ControllerBase
    {
        #region Dependency Injection

        #endregion

        [HttpPost]
        public async Task<ApiResult<object>> Upload([FromForm] List<IFormFile> Files)
        {
            var result = new List<PreviewFileVM>();
            Thread.Sleep(5000);
            foreach (var file in Files)
            {
                result.Add(new PreviewFileVM(Guid.NewGuid().ToString(),
                    "https://cf.bstatic.com/xdata/images/hotel/max1024x768/171764238.jpg?k=00b6ecacd87725586a1959d1af9612b2cd84d85b909bf071818a13645148804b&o=&hp=1",
                    true));
            }
            return Ok(result);
        }
    }
}