using Microsoft.EntityFrameworkCore;
using CustomerService.Core.Entities;

namespace CustomerService.Persistence.Repositories;

public class CustomerRepository : IRepository<CustomerEntity>
{
    private readonly DatabaseContext _dbContext;

    public CustomerRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CustomerService.Core.Entities.CustomerEntity?> GetById(Guid id)
    {
        return await _dbContext.Customers.FindAsync(id) ?? null;
    }

    public async Task<List<CustomerService.Core.Entities.CustomerEntity>> GetAll()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    public async Task Add(CustomerService.Core.Entities.CustomerEntity customerEntity)
    {
        _dbContext.Customers.Add(customerEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(CustomerService.Core.Entities.CustomerEntity customerEntity)
    {
        _dbContext.Customers.Update(customerEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(CustomerService.Core.Entities.CustomerEntity customerEntity)
    {
        _dbContext.Customers.Remove(customerEntity);
        await _dbContext.SaveChangesAsync();
    }
}