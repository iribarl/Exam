using Exam.Domain.Common;
using Exam.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Exam.Infrastructure.Repositories
{
    public class RepositoryBase<TContext, T> : IRepositoryBase<T> 
        where T : class 
        where TContext : DbContext
    {
        protected TContext RepositoryContext;
        public RepositoryBase(TContext context) => RepositoryContext = context;

        public async Task<IEnumerable<T>> FindAllAsync(CancellationToken token)
            => await RepositoryContext.Set<T>().AsNoTracking().ToListAsync(token);

        public async Task<PagedData<T>> GetPaged(PaginationParam param, CancellationToken token)
        {
            var total = await RepositoryContext.Set<T>().CountAsync(token);
            var data = await RepositoryContext.Set<T>()
                                .Skip(param.pageNumber * param.pageSize)
                                .Take(param.pageSize)
                                .AsNoTracking()
                                .ToListAsync(token);
            return new PagedData<T> { TotalRows = total, Rows = data };
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, CancellationToken token)
            => await RepositoryContext.Set<T>().Where(expression).AsNoTracking().ToListAsync(token);


        public async Task<T?> FindByKeyAsync(CancellationToken token, params object[] keyValues)
            => await RepositoryContext.Set<T>().FindAsync(keyValues);


        public async Task Create(T entity, CancellationToken token)
        {
            await RepositoryContext.Set<T>().AddAsync(entity, token);
            await SaveAsync(token);
        }

        public async Task Update(CancellationToken token, T entity, params object[] keyValues)
        {
            var item = await RepositoryContext.Set<T>().FindAsync(keyValues);

            if (item != null)
            {
                RepositoryContext.Entry(item).State = EntityState.Detached;
                RepositoryContext.Entry(entity).State = EntityState.Modified;
                RepositoryContext.Set<T>().Update(entity);
                await SaveAsync(token);
            }
        }

        public async Task Delete(T entity, CancellationToken token)
        {
            RepositoryContext.Set<T>().Remove(entity);
            await SaveAsync(token);
        }

        public async Task DeleteByKeyValue(CancellationToken token, params object[] keyValues)
        {
            var item = await RepositoryContext.Set<T>().FindAsync(keyValues);
            if (item is not null)
                await Delete(item, token);
        }

        public async Task SaveAsync(CancellationToken token)
            => await RepositoryContext.SaveChangesAsync(token);

        public async Task<bool> Exist(params object[] keyValues)
            => await RepositoryContext.Set<T>().FindAsync(keyValues) is not null;
        



    }
}
