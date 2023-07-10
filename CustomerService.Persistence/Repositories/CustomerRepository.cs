using CustomerService.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Persistence.Repositories;

public class CustomerRepository : IRepository<CustomerEntity>
{
    private readonly DatabaseContext _dbContext;

    public CustomerRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CustomerEntity?> GetById(Guid id)
    {
        return await _dbContext.Customers.FindAsync(id) ?? null;
    }

    public async Task<List<CustomerEntity>> GetAll()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    public async Task Add(CustomerEntity customerEntity)
    {
        _dbContext.Customers.Add(customerEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(CustomerEntity customerEntity)
    {
        _dbContext.Customers.Update(customerEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(CustomerEntity customerEntity)
    {
        _dbContext.Customers.Remove(customerEntity);
        await _dbContext.SaveChangesAsync();
    }
}