using Exam.Application.DTOs;
using Exam.Domain.Common;
using System.Linq.Expressions;

namespace Exam.Application.Interfaces
{
    public interface IServiceBase<T, TEntity>
        where T : class
        where TEntity : class
    {
        Task Add(T entity, CancellationToken token);
        Task Update(CancellationToken token, T entity, params object[] keyValues);
        Task<IEnumerable<T>> GetAll(CancellationToken token);
        Task<T?> GetbyKey(CancellationToken token, params object[] keyValues);
        Task<IEnumerable<T>> GetbyCondition(Expression<Func<TEntity, bool>> expression, CancellationToken token);
        Task Remove(T entity, CancellationToken token);
        Task RemoveByKey(CancellationToken token, params object[] keyValues );
        Task<PagedData<T>> GetPaged(PaginationParam param, CancellationToken token);
        Task<bool> Exist(params object[] keyValues);

    }
}