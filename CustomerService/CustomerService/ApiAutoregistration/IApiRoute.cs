namespace CustomerService.ApiAutoregistration;

public interface IApiRoute
{
    void MapEndpoint(IEndpointRouteBuilder builder);
}