namespace CustomerService.Persistence.Repositories;

public interface IRepository<T>
{
    Task<T?> GetById(Guid id);
    Task<List<Core.Entities.CustomerEntity>> GetAll();
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}