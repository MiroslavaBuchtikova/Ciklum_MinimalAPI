using CustomerService.ApiAutoregistration;
using CustomerService.Features.Authorization.SwaggerDocumentation;
using MediatR;

namespace CustomerService.Features.Authorization.Endpoints;

public class GetAuthorizationTokenEndpoint : IApiRoute
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost($"{EndpointConfiguration.BaseApiPath}/security/getToken", GetAuthToken)
            .WithApiVersionSet(builder.NewApiVersionSet("Authentication").Build())
            .HasApiVersion(1.0)
            .HasApiVersion(2.0)
            .WithOpenApi(GetAuthorizationTokenConfiguration.ConfigureOpenApiOperation);
    }

    private static async Task<IResult> GetAuthToken(IMediator mediator)
    {
        var request = new Queries.GetAuthorizationTokenQuery();
        var jwtToken = await mediator.Send(request);

        return Results.Ok(jwtToken);
    }
}