using Asp.Versioning.Builder;
using MediatR;
using MinimalAPI.ApiAutoregistration;
using MinimalAPI.Features.Customer.Commands;
using MinimalAPI.Features.Customer.DTOs;
using MinimalAPI.Features.Customer.SwaggerDocumentation;

namespace MinimalAPI.Features.Customer.Endpoints.v2;

public class CreateCustomer : BaseApiRoute
{
    protected override string RouteName => "Customers";
    protected override string Version => "v2";
    protected override int ApiVersion => 2;
    protected override bool RequireAuthorization => true;

    protected override void MapEndpoints(IVersionedEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost($"{Version}/customers", Create)
            .WithOpenApi(CreateCustomerConfiguration.ConfigureOpenApiOperation);
    }

    private async Task<ResultDto> Create (DTOs.CustomerDto customerDto, IMediator mediator)
    {
        var request = new CreateCustomerCommand(customerDto);
        return await mediator.Send(request);
    }

 
}