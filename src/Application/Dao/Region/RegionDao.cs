using Application.Extentions;
using Application.Interfaces.Context;
using Application.Models;
using Domain.Entities;
using Domain.Enums;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Dao
{
    public class RegionDao : BaseDao<Region, long>, IRegionDao
    {
        #region Dependency Injection
        private readonly IDbContext context;

        public RegionDao(IDbContext _context) : base(_context)
        {
            context = _context;
        }
        #endregion

        public async Task<PaginatedList<TDestination>> GetAllAsync<TDestination>(int page = 1, int pageSize = 20, string? keyword = null,
            bool tracking = false, TypeAdapterConfig? config = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var init = context.Regions.OrderBy(u => u.Name).AsQueryable();

            if (!tracking)
                init = init.AsNoTracking();
            // search
            if (!string.IsNullOrEmpty(keyword))
                init = init.Where(r => keyword.Contains(r.Name) || keyword.Contains(r.Parent.Name));

            return await init
                .ProjectToType<TDestination>(config)
                .PaginatedListAsync(page, pageSize, cancellationToken);
        }

        public async Task<List<Region>> GetProvinces(bool withChildren = false,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var initRegions = context.Regions.Where(r => r.Type == RegionType.Province)
                .OrderBy(r => r.Name).AsQueryable();

            if (withChildren)
            {
                initRegions.Include(r => r.Children);
            }

            return await initRegions.ToListAsync(cancellationToken);
        }
    }
}