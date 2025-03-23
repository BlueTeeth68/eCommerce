using System.Linq.Expressions;
using Application.Dtos.Response.Paging;
using Domain.Entities.Generics;

namespace Application.Interfaces.IRepositories.Generic;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAsync(
        Expression<Func<T, bool>>? filter,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        string? includeProperties = null,
        bool disableTracking = false
    );

    IQueryable<T> GetAll();

    Task<PagingResponse<T>> GetPaginateAsync(
        Expression<Func<T, bool>>? filter,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
        int? page,
        int? size,
        string? includeProperties = null,
        bool disableTracking = false
    );

    // Task<T?> GetByIdAsync(object id, string? includeProperties = null, bool disableTracking = false);
    Task<T?> GetByIdAsync(int id, bool disableTracking = false);

    Task AddAsync(T entity);

    Task AddRangeAsync(IEnumerable<T> entities);

    void Update(T entity);

    void UpdateRange(IEnumerable<T> entities);

    void Delete(T entity);

    void DeleteRange(IEnumerable<T> entities);

    Task<bool> ExistById(int id);
}