using Application.Common.Dynamic;
using Application.Common.Pagination;
using Application.Services.Repositories.GenericRepositories.Abstractions;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Repositories.GenericRepositories;

public class EfRepositoryBase<TEntity, TEntityId, TContext> :
    IAsyncRepository<TEntity, TEntityId>
    // IRepository<TEntity, TEntityId> //Senkron senaryolar olursa burayı açıp implement edip operasyonları yazınız.
    where TEntity : BaseEntity<TEntityId>
    where TContext : DbContext
{
    protected readonly TContext Context;

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }


    public async Task<TEntity> AddAsync(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        entity.LastModified = DateTime.UtcNow;

        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities)
    {
        foreach (var entity in entities)
            entity.CreatedDate = DateTime.UtcNow;

        await Context.AddRangeAsync(entities);
        await Context.SaveChangesAsync();
        return entities;

    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (predicate != null)
            queryable = queryable.Where(predicate);
        return await queryable.AnyAsync(cancellationToken);
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        Context.Remove(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public async Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities)
    {
        foreach (var entity in entities)
            Context.RemoveRange(entities);
        await Context.SaveChangesAsync();

        return entities;
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);

        return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<Paginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);
        if (predicate != null)
            queryable = queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToPaginateAsync(index, size, cancellationToken);

        return await queryable.ToPaginateAsync(index, size, cancellationToken);

    }

    public async Task<Paginate<TEntity>> GetListByDynamicAsync(DynamicQuery dynamic, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query().ToDynamic(dynamic);
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);
        if (predicate != null)
            queryable = queryable.Where(predicate);

        return await queryable.ToPaginateAsync(index, size, cancellationToken);
    }

    public IQueryable<TEntity> Query() => Context.Set<TEntity>();

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.LastModified = DateTime.UtcNow;
        Context.Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities)
    {
        foreach (var entity in entities)
            entity.LastModified = DateTime.UtcNow;
        Context.UpdateRange(entities);
        await Context.SaveChangesAsync();
        return entities;

    }





}
