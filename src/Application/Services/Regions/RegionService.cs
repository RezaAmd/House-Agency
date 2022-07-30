using Application.Models;

namespace Application.Services.Regions;

public class RegionService : IRegionService
{
    #region Constructors
    private readonly IRegionRepository _regionRepository;

    public RegionService(IRegionRepository regionRepository)
    {
        _regionRepository = regionRepository;
    }
    #endregion

    public async Task<Result> CreateAsync(Region region, CancellationToken stoppingToken = default)
    {
        bool isSaved = await _regionRepository.AddAsync(region, true, stoppingToken);
        return isSaved ? Result.Success : Result.Failed();
    }

    public async Task<Result> RemoveAsync(Region region, CancellationToken stoppingToken = default)
    {
        bool isDeleted = await _regionRepository.DeleteAsync(region, true, stoppingToken);
        return isDeleted ? Result.Success : Result.Failed();
    }
}