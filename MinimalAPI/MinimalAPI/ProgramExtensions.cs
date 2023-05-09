using System.Text;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MinimalAPI.Persistence;
using MinimalAPI.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MinimalAPI;

public static class ProgramExtensions
{
    public static void RegisterApplicationsServices(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddDbContext<CustomerDb>(opt => opt.UseInMemoryDatabase("CustomerList"));
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Singleton);

        services.AddApiVersioning()
            .AddApiExplorer()
            .EnableApiVersionBinding();
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddAuthentication().AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
            };
        });
        services.AddAuthorization();
        services.AddMemoryCache();
    }
}