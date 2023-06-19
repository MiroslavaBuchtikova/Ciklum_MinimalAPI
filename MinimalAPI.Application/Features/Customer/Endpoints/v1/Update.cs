using Asp.Versioning.Builder;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using MinimalAPI.Application.ApiAutoregistration;
using MinimalAPI.Application.Features.Customer.SwaggerDocumentation;

namespace MinimalAPI.Application.Features.Customer.Endpoints;

public class UpdateCustomer : BaseApiRoute
{
    protected override string RouteName => "Customers";
    protected override string Version => "v1";
    protected override int ApiVersion => (int)1.0;

    protected override void MapEndpoints(IVersionedEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPut($"{Version}/customers/{{id}}", Update)
            .WithOpenApi(UpdateCustomerConfiguration.ConfigureOpenApiOperation);
    }

    private async Task<DomainModels.Customer> Update(Guid id, DomainModels.Customer customerDto,
        Persistence.Repositories.Customer customer,
        IMapper mapper, IMediator mediator)
    {
        var command = new Commands.Update() { Id = id, Customer = customerDto };
        return await mediator.Send(command);
    }
}