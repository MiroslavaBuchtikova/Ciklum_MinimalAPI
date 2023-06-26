using Asp.Versioning.Builder;
using MinimalAPI.Filters;

namespace MinimalAPI.ApiAutoregistration;

public abstract class BaseApiRoute : IApiRoute
{
    protected abstract string RouteName { get; }

    protected abstract string Version { get; }

    protected abstract int ApiVersion { get; }

    protected abstract bool RequireAuthorization { get; }

    public void Register(WebApplication group)
    {
        var versionedGroup = group.NewVersionedApi(RouteName).HasApiVersion(ApiVersion, 0)
            .AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory);
        if (RequireAuthorization)
        {
            versionedGroup.RequireAuthorization();
        }

        MapEndpoints(versionedGroup);
    }

    protected abstract void MapEndpoints(IVersionedEndpointRouteBuilder routeBuilder);
}