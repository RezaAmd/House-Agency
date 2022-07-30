using Application.Extensions;
using Application.Interfaces.Context;
using Application.Models;
using Domain.Entities.Identity;
using Mapster;

namespace Application.Repositories.Roles;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    #region Constructor
    private readonly IDbContext _context;
    public RoleRepository(IDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    public async Task<PaginatedList<TDestination>> GetAllAsync<TDestination>(string? keyword = null, int page = 1, int pageSize = 30,
        CancellationToken cancellationToken = new(), TypeAdapterConfig? config = null)
    {
        var roles = _context.Roles.AsQueryable();
        #region Filter
        // Search with name, title, description
        if (!string.IsNullOrEmpty(keyword))
            roles = roles.Where(x => x.Name.Contains(keyword)
            || x.Title.Contains(keyword)
            || x.Description.Contains(keyword));
        #endregion
        return await roles
            .ProjectToType<TDestination>(config)
            .PaginatedListAsync(page, pageSize, cancellationToken);
    }
}