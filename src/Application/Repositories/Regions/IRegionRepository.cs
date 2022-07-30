using Application.Models;
using Mapster;

namespace Application.Repositories.Regions;

public interface IRegionRepository : IBaseRepository<Region>
{
    /// <summary>
    /// Get all regions with pagination.
    /// </summary>
    Task<PaginatedList<TDestination>> GetAllAsync<TDestination>(int page = 1, int pageSize = 20, string? keyword = null,
        bool tracking = false, TypeAdapterConfig? config = null,
        CancellationToken cancellationToken = new CancellationToken());

    Task<List<Region>> GetCitiesAsync(bool withChildren = false,
        CancellationToken cancellationToken = new CancellationToken());

    Task<Result> CreateAsync(Region region, CancellationToken stoppingToken = default);
}