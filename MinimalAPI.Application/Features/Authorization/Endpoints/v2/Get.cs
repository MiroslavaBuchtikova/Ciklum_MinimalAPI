using Asp.Versioning.Builder;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MinimalAPI.Application.ApiAutoregistration;
using MinimalAPI.Application.Features.Authorization.SwaggerDocumentation;

namespace MinimalAPI.Application.Features.Authorization.Endpoints.v2;

public class Get : BaseApiRoute
{
    protected override string RouteName => "Security";
    protected override string Version => "v2";

    protected override int ApiVersion => (int)2.0;


    protected override void MapEndpoints(IVersionedEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost($"{Version}/security/getToken", GetAuthToken)
            .WithOpenApi(GetAuthorizationTOkenConfiguration.ConfigureOpenApiOperation);
    }


    private static async Task<IResult> GetAuthToken(IMediator mediator)
    {
        var request = new Queries.Get();
        var jwtToken = await mediator.Send(request);

        return Results.Ok(jwtToken);
    }
}