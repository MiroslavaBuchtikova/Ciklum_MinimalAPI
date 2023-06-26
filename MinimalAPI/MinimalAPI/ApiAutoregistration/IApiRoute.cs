namespace MinimalAPI.ApiAutoregistration;

public interface IApiRoute
{
    void MapEndpoint(IEndpointRouteBuilder builder);
}