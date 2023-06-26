using MediatR;
using MinimalAPI.ApiAutoregistration;
using MinimalAPI.Features.Authorization.SwaggerDocumentation;

namespace MinimalAPI.Features.Authorization.Endpoints.v1;

public class Get : IApiRoute
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost($"{EndpointConfiguration.BaseApiPath}/security/getToken", GetAuthToken)
            .WithApiVersionSet(builder.NewApiVersionSet("Authentication").Build())
            .HasApiVersion(1.0)
            .WithOpenApi(GetAuthorizationTokenConfiguration.ConfigureOpenApiOperation);
    }

    private static async Task<IResult> GetAuthToken(IMediator mediator)
    {
        var request = new Queries.Get();
        var jwtToken = await mediator.Send(request);

        return Results.Ok(jwtToken);
    }
}