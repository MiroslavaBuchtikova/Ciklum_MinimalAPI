using Microsoft.EntityFrameworkCore;
using MinimalAPI.Core.Entities;

namespace CustomerService.Persistence.Repositories;

public class CustomerRepository : IRepository<Customer>
{
    private readonly DatabaseContext _dbContext;

    public CustomerRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<MinimalAPI.Core.Entities.Customer?> GetById(Guid id)
    {
        return await _dbContext.Customers.FindAsync(id) ?? null;
    }

    public async Task<List<MinimalAPI.Core.Entities.Customer>> GetAll()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    public async Task Add(MinimalAPI.Core.Entities.Customer customer)
    {
        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(MinimalAPI.Core.Entities.Customer customer)
    {
        _dbContext.Customers.Update(customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(MinimalAPI.Core.Entities.Customer customer)
    {
        _dbContext.Customers.Remove(customer);
        await _dbContext.SaveChangesAsync();
    }
}