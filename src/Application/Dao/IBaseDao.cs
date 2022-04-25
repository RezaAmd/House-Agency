using Application.Models;

namespace Application.Dao
{
    public interface IBaseDao<TEntity, TKey> where TEntity : class
    {
        Task<TEntity?> FindByIdAsync(TKey id, CancellationToken cancellationToken = new());
        Task<Result> CreateAsync(TEntity entry, CancellationToken cancellationToken = new CancellationToken());
        Task<Result> UpdateAsync(TEntity entry, CancellationToken cancellationToken = new CancellationToken());
        Task<Result> DeleteAsync(TEntity role, CancellationToken cancellationToken = new CancellationToken());
        IQueryable<TEntity> Table { get; }
    }
}