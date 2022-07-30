using Application.Extensions;
using Application.Models;
using Application.Repositories.Regions;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using WebApi.Areas.Manage.Models;

namespace WebApi.Areas.Manage.Controllers;

[ApiController]
[Area("Manage")]
[Route("[area]/[controller]/[action]")]
//[Authorize(Roles = "ManageRegions")]
public class RegionController : ControllerBase
{
    #region Dependency Injection
    private readonly IRegionRepository _regionRepository;
    public RegionController(IRegionRepository regionRepository)
    {
        _regionRepository = regionRepository;
    }
    #endregion

    [HttpGet]
    public async Task<ApiResult<object>> GetCitiesWithChildren([FromQuery] string? keyword, [FromQuery] PaginationParameter pagination = default,
        CancellationToken cancellationToken = new())
    {
        var regions = await _regionRepository.GetCitiesAsync(true, cancellationToken);
        if (regions.Count > 0)
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
            var parentRegion = await _regionRepository.FindByIdAsync(cancellationToken ,model.ParentId.Value);
            if (parentRegion != null)
                regionType = parentRegion.Type == RegionType.Province ?
                    RegionType.City :
                    (parentRegion.Type == RegionType.City ?
                    RegionType.neighborhood : RegionType.Province);
            else
                regionType = RegionType.Province;
        }

        var newRegion = new Region(model.Name, regionType);

        var createRegionResult = await _regionRepository.CreateAsync(newRegion, cancellationToken);
        if (createRegionResult.Succeeded)
        {
            return Ok(new CreateRegionMVM(newRegion.Id));
        }

        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<ApiResult<object>> Delete([FromRoute] long id, CancellationToken cancellationToken = new())
    {
        var region = await _regionRepository.FindByIdAsync(cancellationToken, id);
        if (region != null)
        {
            var deleteRegionResult = await _regionRepository.DeleteAsync(region);
            if (deleteRegionResult)
            {
                return Ok($"'{region.Name}' با موفقیت حذف شد.");
            }
            return BadRequest();
        }
        return NotFound("موردی یافت نشد.");
    }
}