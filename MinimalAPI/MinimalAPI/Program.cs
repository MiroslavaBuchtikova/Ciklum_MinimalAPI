using System.Reflection;
using MinimalAPI;
using MinimalAPI.ApiAutoregistration;
using MinimalAPI.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterApplicationsServices(builder.Configuration);


builder.Host.UseSerilog((hostContext, services, configuration) =>
{
    configuration
        .WriteTo.File("serilog-file.txt")
        .WriteTo.Console();
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<CustomErrorHandlerMiddleware>();

app.RegisterApiRoutes();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            var descriptions = app.DescribeApiVersions();

            foreach (var description in descriptions)
            {
                var url = $"/swagger/{description.GroupName}/swagger.json";
                var name = description.GroupName.ToUpperInvariant();
                options.SwaggerEndpoint(url, name);
                options.RoutePrefix = String.Empty;
            }
        });
}

app.Run();

public partial class Program
{
}