using Microsoft.EntityFrameworkCore;
using CustomerService.Core.Entities;

namespace CustomerService.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();
}