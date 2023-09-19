using Application.Common.Dynamic;
using Application.Common.Pagination;
using Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Repositories.GenericRepositories.Abstractions;

public interface IRepository<TEntity, TEntityId> : IQuery<TEntity>
    where TEntity : BaseEntity<TEntityId>
{
    TEntity? Get(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool enableTracking = true);

    Paginate<TEntity> GetList(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool enableTracking = true);


    Paginate<TEntity> GetListByDynamic(
        DynamicQuery dynamic,
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool enableTracking = true);

    bool Any(Expression<Func<TEntity, bool>>? predicate = null, bool enableTracking = true);

    TEntity Add(TEntity entity);

    ICollection<TEntity> AddRange(ICollection<TEntity> entities);

    TEntity Update(TEntity entity);

    ICollection<TEntity> UpdateRange(ICollection<TEntity> entities);

    TEntity Delete(TEntity entity);

    ICollection<TEntity> DeleteRange(ICollection<TEntity> entities);

}
