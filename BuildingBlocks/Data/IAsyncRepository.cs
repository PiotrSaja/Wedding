﻿using System.Linq.Expressions;

namespace BuildingBlocks.Data
{
    public interface IAsyncRepository<T> where T : class, IEntity
    {
        Task<T?> GetById(int id);
        Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);
    }
}
