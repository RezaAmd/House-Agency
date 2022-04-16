using Application.Models;
using Domain.Entities.Identity;
using Mapster;

namespace Application.Dao
{
    public interface IRoleService
    {
        Task<PaginatedList<TDestination>> GetAllAsync<TDestination>(string? keyword, int page = 1, int pageSize = 30,
            CancellationToken cancellationToken = new(), TypeAdapterConfig? config = null);

        Task<Role?> FindByIdAsync(string id, CancellationToken cancellationToken = new());

        Task<Result> CreateAsync(Role role, CancellationToken cancellationToken = new());

        Task<Result> UpdateAsync(Role role, CancellationToken cancellationToken = new());

        Task<Result> DeleteAsync(Role role, CancellationToken cancellationToken = new());
    }
}