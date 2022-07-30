using Application.Extensions;
using Application.Interfaces.Context;
using Application.Models;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Permissions;

public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
{
    #region DI
    private readonly IDbContext _context;

    public PermissionRepository(IDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion

    public Task<PaginatedList<Permission>> GetAllAsync(string? keyword = null, int page = 1, int pageSize = 15,
        bool withRoles = false,
        CancellationToken cancellationToken = default)
    {
        var permissions = _context.Permissions.AsQueryable();
        #region Filter
        // Search with name, title, description.
        if (!string.IsNullOrEmpty(keyword))
            permissions = permissions.Where(p => p.Name.Contains(keyword)
            || p.Title.Contains(keyword)
            || p.Description.Contains(keyword));

        if (withRoles)
            permissions = permissions.Include(p => p.PermissionRoles).ThenInclude(r => r.Role);
        #endregion
        return permissions.PaginatedListAsync(page, pageSize, cancellationToken);
    }
}