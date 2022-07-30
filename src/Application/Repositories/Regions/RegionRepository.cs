using Application.Extensions;
using Application.Interfaces.Context;
using Application.Models;
using Domain.Enums;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Regions;

public class RegionRepository : BaseRepository<Region>, IRegionRepository
{
    #region Dependency Injection
    private readonly IDbContext _context;

    public RegionRepository(IDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion

    public async Task<PaginatedList<TDestination>> GetAllAsync<TDestination>(int page = 1, int pageSize = 20, string? keyword = null,
        bool tracking = false, TypeAdapterConfig? config = null,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var init = _context.Regions.OrderBy(u => u.Name).AsQueryable();

        if (!tracking)
            init = init.AsNoTracking();
        // search
        if (!string.IsNullOrEmpty(keyword))
            init = init.Where(r => keyword.Contains(r.Name) || keyword.Contains(r.Parent.Name));

        return await init
            .ProjectToType<TDestination>(config)
            .PaginatedListAsync(page, pageSize, cancellationToken);
    }

    public async Task<List<Region>> GetCitiesAsync(bool withChildren = false,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var initRegions = _context.Regions.Where(r => r.Type == RegionType.City)
            .OrderBy(r => r.Name).AsQueryable();

        if (withChildren)
        {
            initRegions = initRegions.Include(r => r.Children);
        }

        return await initRegions.ToListAsync(cancellationToken);
    }

    public async Task<Result> CreateAsync(Region region, CancellationToken stoppingToken = default)
    {
        bool isSaved = await AddAsync(region, true, stoppingToken);
        return isSaved ? Result.Success : Result.Failed();
    }
}