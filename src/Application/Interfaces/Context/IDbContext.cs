using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Context
{
    public interface IDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Permission> Permissions { get; set; }

        DbSet<Region> Regions { get; set; }
        DbSet<Attachment> Attachments { get; set; }
        DbSet<Possession> Possessions { get; set; }
    }
}