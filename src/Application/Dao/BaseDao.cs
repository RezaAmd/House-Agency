using Application.Interfaces.Context;
using Application.Models;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Dao
{
    public class BaseDao<TEntity, TKey> : IBaseDao<TEntity, TKey> where TEntity : BaseEntity
    {
        #region Dependency Injection
        private readonly IDbContext context;
        private DbSet<TEntity> entities;

        public BaseDao(IDbContext _context)
        {
            context = _context;
            entities = context.Set<TEntity>();
        }
        #endregion

        public async Task<TEntity?> FindByIdAsync(TKey id, CancellationToken cancellationToken = new())
        {
            return await entities.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<Result> CreateAsync(TEntity entry, CancellationToken cancellationToken = new CancellationToken())
        {
            await entities.AddAsync(entry);
            if (Convert.ToBoolean(await context.SaveChangesAsync(cancellationToken)))
                return Result.Success;
            return Result.Failed();
        }

        public async Task<Result> UpdateAsync(TEntity entry, CancellationToken cancellationToken = new CancellationToken())
        {
            entities.Update(entry);
            if (Convert.ToBoolean(await context.SaveChangesAsync(cancellationToken)))
                return Result.Success;
            return Result.Failed();
        }

        public async Task<Result> DeleteAsync(TEntity role, CancellationToken cancellationToken = new CancellationToken())
        {
            entities.Remove(role);
            if (Convert.ToBoolean(await context.SaveChangesAsync(cancellationToken)))
                return Result.Success;
            return Result.Failed();
        }

        public virtual IQueryable<TEntity> Table
        {
            get
            {
                return this.Entities;
            }
        }

        public DbSet<TEntity> Entities
        {
            get
            {
                if (this.entities == null)
                {
                    entities = context.Set<TEntity>();
                }
                return entities;
            }
        }
    }
}