namespace CustomerService.Persistence.Repositories;

public interface IRepository<T>
{
    Task<T?> GetById(Guid id);
    Task<List<MinimalAPI.Core.Entities.Customer>> GetAll();
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}