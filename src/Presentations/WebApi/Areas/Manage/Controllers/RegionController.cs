using Application.Extentions;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Manage.Models;

namespace WebApi.Areas.Manage.Controllers
{
    [ApiController]
    [Area("Manage")]
    [Route("[controller]/[action]")]
    //[Authorize(Roles = "ManageRegions")]
    public class RegionController : ControllerBase
    {
        #region Dependency Injection

        public RegionController()
        {

        }
        #endregion

        [HttpGet]
        public async Task<ApiResult> GetAll([FromQuery] string? keyword, int page = 1, CancellationToken cancellationToken = new())
        {

            return NotFound();
        }

        [HttpPost]
        [ModelStateValidator]
        public async Task<ApiResult> Create([FromBody] CreateRegionDto model, CancellationToken cancellationToken = new())
        {

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> Delete([FromRoute] long id, CancellationToken cancellationToken = new())
        {

            return NotFound();
        }
    }
}
