using Microsoft.EntityFrameworkCore;
using MinimalAPI.Core.Entities;

namespace MinimalAPI.Persistence;

public class CustomerDb : DbContext
{
    public CustomerDb(DbContextOptions<CustomerDb> options) : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();
}