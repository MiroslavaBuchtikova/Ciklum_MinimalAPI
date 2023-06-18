using MinimalAPI.MinimalAPI.Core.Entities;

namespace MinimalAPI.MinimalAPI.Persistence.Repositories;

public interface IRepository<T>
{
    Task<T?> GetById(Guid id);
    Task<List<Customer>> GetAll();
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}