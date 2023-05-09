using Microsoft.EntityFrameworkCore;
using MinimalAPI.Entities;

namespace MinimalAPI.Persistence;

public class CustomerDb : DbContext
{
    public CustomerDb(DbContextOptions<CustomerDb> options) : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();
}