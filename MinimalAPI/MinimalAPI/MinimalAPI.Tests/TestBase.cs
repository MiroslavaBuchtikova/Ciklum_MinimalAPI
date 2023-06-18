using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MinimalAPI.MinimalAPI.Persistence;

namespace MinimalAPI.MinimalAPI.Tests;

public class TestBase
{
    private readonly WebApplicationFactory<Program> _server;

    public TestBase()
    {
        _server = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Testing");
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton(_ =>
                    {
                        var dbContextOptions = new DbContextOptionsBuilder<CustomerDb>()
                            .UseInMemoryDatabase($"CustomerDb_Test{Guid.NewGuid()}").Options;
                        var dbContext = new CustomerDb(dbContextOptions);
                        return dbContext;
                    });

                    services.BuildServiceProvider();
                });
            });
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