using Asp.Versioning.Builder;
using MediatR;
using Microsoft.AspNetCore.Builder;
using MinimalAPI.Application.ApiAutoregistration;
using MinimalAPI.Application.Features.Customer.Commands;
using MinimalAPI.Application.Features.Customer.SwaggerDocumentation;

namespace MinimalAPI.Application.Features.Customer.Endpoints.v2;

public class CreateCustomer : BaseApiRoute
{
    protected override string RouteName => "Customers";
    protected override string Version => "v2";
    protected override int ApiVersion => (int)2.0;

    protected override void MapEndpoints(IVersionedEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost($"{Version}/customers", Create)
            .WithOpenApi(CreateCustomerConfiguration.ConfigureOpenApiOperation);
    }

    private async Task<DomainModels.Customer> Create (DomainModels.Customer customer, IMediator mediator)
    {
        var request = new Create(customer);
        return await mediator.Send(request);
    }
}