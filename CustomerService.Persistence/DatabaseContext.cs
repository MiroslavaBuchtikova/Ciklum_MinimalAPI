using Microsoft.EntityFrameworkCore;
using MinimalAPI.Core.Entities;

namespace CustomerService.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();
}