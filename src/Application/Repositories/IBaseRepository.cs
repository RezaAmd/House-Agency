﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    DbSet<TEntity> Entities { get; }
    IQueryable<TEntity> Table { get; }
    IQueryable<TEntity> TableNoTracking { get; }

    TEntity? FindById(params object[] id);
    Task<TEntity?> FindByIdAsync(CancellationToken stoppingToken = default, params object[] id);
    List<TEntity> GetAll(bool asNoTracking);
    Task<List<TEntity>> GetAllAsync(bool asNoTracking, CancellationToken stoppingToken = default);

    bool Add(TEntity entity, bool saveNow = true);
    Task<bool> AddAsync(TEntity entity, bool saveNow = true, CancellationToken stoppingToken = default);
    bool AddRange(IEnumerable<TEntity> entities, bool saveNow = true);
    Task<bool> AddRangeAsync(IEnumerable<TEntity> entities, bool saveNow = true, CancellationToken stoppingToken = default);

    bool Update(TEntity entity, bool saveNow = true);
    Task<bool> UpdateAsync(TEntity entity, bool saveNow = true, CancellationToken stoppingToken = default);
    bool UpdateRange(IEnumerable<TEntity> entities, bool saveNow = true);
    Task<bool> UpdateRangeAsync(IEnumerable<TEntity> entities, bool saveNow = true, CancellationToken stoppingToken = default);

    bool Delete(TEntity entity, bool saveNow = true);
    Task<bool> DeleteAsync(TEntity entity, bool saveNow = true, CancellationToken stoppingToken = default);
    bool DeleteRange(IEnumerable<TEntity> entities, bool saveNow = true);
    Task<bool> DeleteRangeAsync(IEnumerable<TEntity> entities, bool saveNow = true, CancellationToken stoppingToken = default);

    bool IsExists(Expression<Func<TEntity, bool>> expression);
    Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> expression, CancellationToken stoppingToken = default);
}