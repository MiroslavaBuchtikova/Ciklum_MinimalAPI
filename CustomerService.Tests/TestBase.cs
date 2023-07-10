using System.Net;
using System.Security.Claims;
using CustomerService.Core.Entities;
using CustomerService.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using WebMotions.Fake.Authentication.JwtBearer;

namespace CustomerService.Tests;

public class TestBase
{
    private readonly WebApplicationFactory<Program> _server;


    private readonly DbContextOptions _dbContextOptions
        = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase($"TestDb_{Guid.NewGuid()}")
            .ConfigureWarnings(x =>
            {
                x.Ignore(InMemoryEventId.TransactionIgnoredWarning);
                x.Ignore(CoreEventId.DetachedLazyLoadingWarning);
            }).Options;

    public TestBase()
    {
        _server = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Testing");
                builder.ConfigureServices(services =>
                {
                    services.AddSingleton(GetDbContext(_dbContextOptions));
                    services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = FakeJwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = FakeJwtBearerDefaults.AuthenticationScheme;
                    }).AddFakeJwtBearer();
                    services.BuildServiceProvider();
                });
            });
    }

    private DatabaseContext GetDbContext(DbContextOptions options)
    {
        return new DatabaseContext(options);
    }


    protected HttpClient HttpClient
    {
        get
        {
            var claims =
                new Dictionary<string, object>
                {
                    { ClaimTypes.Name, "test@sample.com" },
                    { ClaimTypes.Role, "admin" },
                    {"scope", "flight-api"}
                };
            var httpClient = _server.CreateClient();
            httpClient.SetFakeBearerToken(claims);
            return httpClient;
        }
    }

    protected CustomerEntity ArrangeDbData()
    {
        using var context = GetDbContext(_dbContextOptions);
        var customer = context.Customers.Add(new CustomerEntity
        {
            Id = Guid.NewGuid(),
            FirstName = "FirstnameTest",
            LastName = "LastNameTest",
            EmailAddress = "EmailTest"
        }).Entity;

        context.SaveChanges();

        return customer;
    }

}