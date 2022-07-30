using Application.Models;

namespace Application.Services.Regions;

public interface IRegionService
{
    Task<Result> CreateAsync(Region region, CancellationToken stoppingToken = default);

    Task<Result> RemoveAsync(Region region, CancellationToken stoppingToken = default);
}