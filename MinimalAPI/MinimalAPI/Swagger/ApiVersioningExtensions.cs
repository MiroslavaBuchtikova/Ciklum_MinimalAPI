using Asp.Versioning;

namespace MinimalAPI.Swagger;

public static class ApiVersioningExtensions
{
    public static void AddCustomVersioning(
        this IServiceCollection services,
        Action<ApiVersioningOptions>? configurator = null)
    {
        services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;

                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);

                options.ApiVersionReader = ApiVersionReader.Combine(
                    new HeaderApiVersionReader("api-version"),
                    new UrlSegmentApiVersionReader());

                configurator?.Invoke(options);
            })
            .AddApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";


                    options.SubstituteApiVersionInUrl = true;
                })
            .AddMvc();
    }
}