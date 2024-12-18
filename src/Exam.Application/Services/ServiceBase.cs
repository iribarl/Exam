namespace Exam.Application.Services
{
    using AutoMapper;
    using Exam.Application.DTOs;
    using Exam.Application.Interfaces;
    using Exam.Domain.Common;
    using Exam.Domain.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class ServiceBase<T, TEntity> : IServiceBase<T, TEntity>
        where T : class
        where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        private readonly IMapper _mapper;

        public ServiceBase(IRepositoryBase<TEntity> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper;   
        }

        public async Task Add(T entity, CancellationToken token)
            => await _repository.Create(_mapper.Map<TEntity>(entity), token);

        public async Task Update(CancellationToken token, T entity, params object[] keyValues)
            => await _repository.Update(token, _mapper.Map<TEntity>(entity), keyValues);

        public async Task<IEnumerable<T>> GetAll(CancellationToken token)
        {
            var data = await _repository.FindAllAsync(token);
            return _mapper.Map<IEnumerable<T>>(data);
        }

        public async Task<T?> GetbyKey(CancellationToken token, params object[] keyValues)
        {
            var data = await _repository.FindByKeyAsync(token, keyValues);
            return _mapper.Map<T>(data);
        }


        public async Task<IEnumerable<T>> GetbyCondition(Expression<Func<TEntity, bool>> expression, CancellationToken token)
        {
            var data = await _repository.FindByConditionAsync(expression, token);
            return _mapper.Map<IEnumerable<T>>(data);
        }

        public async Task Remove(T entity, CancellationToken token)
            => await _repository.Delete(_mapper.Map<TEntity>(entity), token);

        public async Task RemoveByKey(CancellationToken token, params object[] keyValues)
            => await _repository.DeleteByKeyValue(token, keyValues);

        public async Task<PagedData<T>> GetPaged(PaginationParam param, CancellationToken token)
        {
            var data = await _repository.GetPaged(param, token);
            var mappedList = (IEnumerable<T>?)data.Rows.Select(item => _mapper.Map<T>(item)).ToList();
            return new PagedData<T> { TotalRows = data.TotalRows, Rows = mappedList };
        }

        public async Task<bool> Exist(params object[] keyValues)
            => await _repository.Exist(keyValues);

        
    }
}
