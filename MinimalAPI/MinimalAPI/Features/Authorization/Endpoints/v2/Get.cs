using Asp.Versioning.Builder;
using MediatR;
using MinimalAPI.ApiAutoregistration;
using MinimalAPI.Features.Authorization.SwaggerDocumentation;

namespace MinimalAPI.Features.Authorization.Endpoints.v2;

public class Get : BaseApiRoute
{
    protected override string RouteName => "Security";
    protected override string Version => "v2";

    protected override int ApiVersion => 2;
    protected override bool RequireAuthorization => false;


    protected override void MapEndpoints(IVersionedEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost($"{Version}/security/getToken", GetAuthToken)
            .WithOpenApi(GetAuthorizationTokenConfiguration.ConfigureOpenApiOperation);
    }


    private static async Task<IResult> GetAuthToken(IMediator mediator)
    {
        var request = new Queries.Get();
        var jwtToken = await mediator.Send(request);

        return Results.Ok(jwtToken);
    }

    
}