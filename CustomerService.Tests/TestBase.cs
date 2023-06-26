using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text;
using CustomerService.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace MinimalAPI.Tests;

public class TestBase
{
    private readonly WebApplicationFactory<Program> _server;


    protected DbContextOptions DbContextOptions
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
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton(GetDbContext(DbContextOptions));

                    services.BuildServiceProvider();
                });
            });
    }
    
    public DatabaseContext GetDbContext(DbContextOptions options)
    {
        return new DatabaseContext(options);
    }


    public string GetMockedJwtTokenString()
    {
        var configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json");
        var configuration = configurationBuilder.Build();
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("Jwt:Key") ?? string.Empty);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = configuration.GetValue<string>("Jwt:Issuer"),
            Audience = configuration.GetValue<string>("Jwt:Audience"),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public HttpClient CreateCustomerClient()
    {
        var client = _server.CreateClient();
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", GetMockedJwtTokenString());
        return client;
    }

}