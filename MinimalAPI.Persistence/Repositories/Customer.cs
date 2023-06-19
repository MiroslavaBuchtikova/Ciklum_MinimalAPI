using Microsoft.EntityFrameworkCore;
using MinimalAPI.Core.Entities;

namespace MinimalAPI.Persistence.Repositories;

public class Customer : IRepository<Core.Entities.Customer>
{
    private readonly CustomerDb _dbContext;

    public Customer(CustomerDb dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Core.Entities.Customer?> GetById(Guid id)
    {
        return await _dbContext.Customers.FindAsync(id) ?? null;
    }

    public async Task<List<Core.Entities.Customer>> GetAll()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    public async Task Add(Core.Entities.Customer customer)
    {
        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Core.Entities.Customer customer)
    {
        _dbContext.Customers.Update(customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Core.Entities.Customer customer)
    {
        _dbContext.Customers.Remove(customer);
        await _dbContext.SaveChangesAsync();
    }
}