using Application.Models;
using Domain.Entities.Identity;
using Mapster;

namespace Application.Repositories.Roles;

public interface IRoleRepository : IBaseRepository<Role>
{
    Task<PaginatedList<TDestination>> GetAllAsync<TDestination>(string? keyword, int page = 1, int pageSize = 30,
        CancellationToken cancellationToken = new(), TypeAdapterConfig? config = null);
}