using Application.Dao;
using Application.Extentions;
using Application.Models;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Manage.Models;

namespace WebApi.Areas.Manage.Controllers
{
    [ApiController]
    [Area("Manage")]
    [Route("[area]/[controller]/[action]")]
    //[Authorize(Roles = "ManageRegions")]
    public class RegionController : ControllerBase
    {
        #region Dependency Injection
        private readonly IRegionDao regionDao;
        public RegionController(IRegionDao _regionDao)
        {
            regionDao = _regionDao;
        }
        #endregion

        [HttpGet]
        public async Task<ApiResult<object>> GetAll([FromQuery] string? keyword, int page = 1, CancellationToken cancellationToken = new())
        {
            var regions = await regionDao.GetAllAsync<RegionMVM>(page, 20, keyword);
            if (regions.totalCount > 0)
            {
                return Ok(regions);
            }
            return NotFound(regions);
        }

        [HttpPost]
        [ModelStateValidator]
        public async Task<ApiResult<object>> Create([FromBody] CreateRegionDto model, CancellationToken cancellationToken = new())
        {
            var regionType = RegionType.Province;

            if (model.ParentId.HasValue)
            {
                var parentRegion = await regionDao.FindByIdAsync(model.ParentId.Value);
                if (parentRegion != null)
                    regionType = parentRegion.Type == RegionType.Province ?
                        RegionType.City :
                        (parentRegion.Type == RegionType.City ?
                        RegionType.neighborhood : RegionType.Province);
                else
                    regionType = RegionType.Province;
            }

            var newRegion = new Region(model.Name, regionType);

            var createRegionResult = await regionDao.CreateAsync(newRegion, cancellationToken);
            if (createRegionResult.Succeeded)
            {
                return Ok(new CreateRegionMVM(newRegion.Id));
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult<object>> Delete([FromRoute] long id, CancellationToken cancellationToken = new())
        {
            var region = await regionDao.FindByIdAsync(id);
            if (region != null)
            {
                var deleteRegionResult = await regionDao.DeleteAsync(region);
                if (deleteRegionResult.Succeeded)
                {
                    return Ok($"'{region.Name}' با موفقیت حذف شد.");
                }
                return BadRequest();
            }
            return NotFound("موردی یافت نشد.");
        }
    }
}