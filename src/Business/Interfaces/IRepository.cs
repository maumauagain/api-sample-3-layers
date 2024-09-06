﻿using System.Linq.Expressions;

namespace Business.Interfaces;
public interface IRepository<T> : IDisposable where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);
}