using Asp.Versioning.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MinimalAPI.Application.Filters;

namespace MinimalAPI.Application.ApiAutoregistration;

public abstract class BaseApiRoute : IApiRoute
{
    protected abstract string RouteName { get; }
    
    protected abstract string Version { get; }
    
    protected abstract int ApiVersion { get; }

    public void Register(WebApplication group)
    {
        var groupV1 = group.NewVersionedApi(RouteName).HasApiVersion(ApiVersion)
            .AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory).RequireAuthorization();

        MapEndpoints(groupV1);
    }

    protected abstract void MapEndpoints(IVersionedEndpointRouteBuilder routeBuilder);
}