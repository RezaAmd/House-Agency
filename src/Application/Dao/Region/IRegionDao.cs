using Application.Models;
using Domain.Entities;
using Mapster;

namespace Application.Dao
{
    public interface IRegionDao : IBaseDao<Region, long>
    {
        /// <summary>
        /// Get all regions with pagination.
        /// </summary>
        Task<PaginatedList<TDestination>> GetAllAsync<TDestination>(int page = 1, int pageSize = 20, string? keyword = null,
            bool tracking = false, TypeAdapterConfig? config = null,
            CancellationToken cancellationToken = new CancellationToken());
    }
}