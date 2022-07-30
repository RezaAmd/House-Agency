using Application.Extensions;
using Application.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    #region Dependency Injection
    private readonly IDbContext _context;
    public DbSet<TEntity> Entities { get; }
    public virtual IQueryable<TEntity> Table => Entities;
    public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

    public BaseRepository(IDbContext context)
    {
        _context = context;
        Entities = context.Set<TEntity>();
    }
    #endregion

    #region Sync Methods
    public virtual TEntity? FindById(params object[] id) => Entities.Find(id);
    public virtual List<TEntity> GetAll(bool asNoTracking) => (asNoTracking ? TableNoTracking : Entities).ToList();

    public virtual bool Add(TEntity entity, bool saveNow = true)
    {
        Assert.NotNull(entity, nameof(entity));
        Entities.Add(entity);
        return saveNow ? Convert.ToBoolean(_context.SaveChanges()) : false;
    }

    public virtual bool AddRange(IEnumerable<TEntity> entities, bool saveNow = true)
    {
        Assert.NotNull(entities, nameof(entities));
        Entities.AddRange(entities);
        return saveNow ? Convert.ToBoolean(_context.SaveChanges()) : false;
    }

    public virtual bool Update(TEntity entity, bool saveNow = true)
    {
        Assert.NotNull(entity, nameof(entity));
        Entities.Update(entity);
        return saveNow ? Convert.ToBoolean(_context.SaveChanges()) : false;
    }

    public virtual bool UpdateRange(IEnumerable<TEntity> entities, bool saveNow = true)
    {
        Assert.NotNull(entities, nameof(entities));
        Entities.UpdateRange(entities);
        return saveNow ? Convert.ToBoolean(_context.SaveChanges()) : false;
    }

    public virtual bool Delete(TEntity entity, bool saveNow = true)
    {
        Assert.NotNull(entity, nameof(entity));
        Entities.Remove(entity);
        return saveNow ? Convert.ToBoolean(_context.SaveChanges()) : false;
    }

    public virtual bool DeleteRange(IEnumerable<TEntity> entities, bool saveNow = true)
    {
        Assert.NotNull(entities, nameof(entities));
        Entities.RemoveRange(entities);
        return saveNow ? Convert.ToBoolean(_context.SaveChanges()) : false;
    }

    public bool IsExists(Expression<Func<TEntity, bool>> expression)
    {
        return Entities.Any(expression);
    }
    #endregion

    #region Async Method
    public async virtual Task<TEntity?> FindByIdAsync(CancellationToken cancellationToken = default, params object[] ids) =>
        await Entities.FindAsync(ids, cancellationToken);
    public virtual async Task<List<TEntity>> GetAllAsync(bool asNoTracking, CancellationToken cancellationToken = default) =>
        await (asNoTracking ? TableNoTracking : Entities).ToListAsync(cancellationToken);

    public virtual async Task<bool> AddAsync(TEntity entity, bool saveNow = true, CancellationToken cancellationToken = default)
    {
        Assert.NotNull(entity, nameof(entity));
        await Entities.AddAsync(entity, cancellationToken).ConfigureAwait(false);
        return saveNow ? Convert.ToBoolean(await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false)) :
            false;
    }
    public virtual async Task<bool> AddRangeAsync(IEnumerable<TEntity> entities, bool saveNow = true, CancellationToken cancellationToken = default)
    {
        Assert.NotNull(entities, nameof(entities));
        await Entities.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
        return saveNow ? Convert.ToBoolean(await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false)) :
            false;
    }

    public virtual async Task<bool> UpdateAsync(TEntity entity, bool saveNow = true, CancellationToken cancellationToken = default)
    {
        Assert.NotNull(entity, nameof(entity));
        Entities.Update(entity);
        return saveNow ? Convert.ToBoolean(await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false)) :
            false;
    }
    public virtual async Task<bool> UpdateRangeAsync(IEnumerable<TEntity> entities, bool saveNow = true, CancellationToken cancellationToken = default)
    {
        Assert.NotNull(entities, nameof(entities));
        Entities.UpdateRange(entities);
        return saveNow ? Convert.ToBoolean(await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false)) :
            false;
    }

    public virtual async Task<bool> DeleteAsync(TEntity entity, bool saveNow = true, CancellationToken cancellationToken = default)
    {
        Assert.NotNull(entity, nameof(entity));
        Entities.Remove(entity);
        return saveNow ? Convert.ToBoolean(await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false)) :
            false;
    }
    public virtual async Task<bool> DeleteRangeAsync(IEnumerable<TEntity> entities, bool saveNow = true, CancellationToken cancellationToken = default)
    {
        Assert.NotNull(entities, nameof(entities));
        Entities.RemoveRange(entities);
        return saveNow ? Convert.ToBoolean(await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false)) :
            false;
    }

    public async Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> expression, CancellationToken stoppingToken = default)
    {
        return await Entities.AnyAsync(expression, stoppingToken);
    }
    #endregion
}