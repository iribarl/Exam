using Exam.Domain.Common;
using System.Linq.Expressions;

namespace Exam.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> FindAllAsync(CancellationToken token);
        Task<PagedData<T>> GetPaged(PaginationParam param, CancellationToken token);
        Task<T?> FindByKeyAsync(CancellationToken token, params object[] keyValues);
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, CancellationToken token);
        Task Create(T entity, CancellationToken token);
        Task Update(CancellationToken token, T entity, params object[] keyValues);
        Task Delete(T entity, CancellationToken token);
        Task DeleteByKeyValue(CancellationToken token, params object[] keyValues);
        Task SaveAsync(CancellationToken token);
        Task<bool> Exist(params object[] keyValues);
    }
}
