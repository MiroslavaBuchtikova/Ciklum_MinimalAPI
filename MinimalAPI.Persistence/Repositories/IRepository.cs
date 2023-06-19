using MinimalAPI.Core.Entities;

namespace MinimalAPI.Persistence.Repositories;

public interface IRepository<T>
{
    Task<T?> GetById(Guid id);
    Task<List<Core.Entities.Customer>> GetAll();
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}