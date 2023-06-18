using Microsoft.EntityFrameworkCore;
using MinimalAPI.MinimalAPI.Core.Entities;

namespace MinimalAPI.MinimalAPI.Persistence.Repositories;

public class CustomerCommonRepository : IRepository<Customer>
{
    private readonly CustomerDb _dbContext;

    public CustomerCommonRepository(CustomerDb dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Customer?> GetById(Guid id)
    {
        return await _dbContext.Customers.FindAsync(id) ?? null;
    }

    public async Task<List<Customer>> GetAll()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    public async Task Add(Customer customer)
    {
        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Customer customer)
    {
        _dbContext.Customers.Update(customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Customer customer)
    {
        _dbContext.Customers.Remove(customer);
        await _dbContext.SaveChangesAsync();
    }
}