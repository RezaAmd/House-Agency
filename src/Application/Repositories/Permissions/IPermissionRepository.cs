using Application.Models;
using Domain.Entities.Identity;

namespace Application.Repositories.Permissions;

public interface IPermissionRepository : IBaseRepository<Permission>
{
    /// <summary>
    /// Get all permissions
    /// </summary>
    /// <param name="keyword">Keyword for search</param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <param name="withRoles"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PaginatedList<Permission>> GetAllAsync(string? keyword = null, int page = 1, int pageSize = 15,
        bool withRoles = false,
        CancellationToken cancellationToken = default);
}