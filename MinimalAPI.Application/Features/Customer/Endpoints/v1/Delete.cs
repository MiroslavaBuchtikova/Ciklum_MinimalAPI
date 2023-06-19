using Asp.Versioning.Builder;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using MinimalAPI.Application.ApiAutoregistration;
using MinimalAPI.Application.Features.Customer.SwaggerDocumentation;


namespace MinimalAPI.Application.Features.Customer.Endpoints;

public class DeleteCustomer : BaseApiRoute
{
    protected override string RouteName => "Customers";
    protected override string Version => "v1";
    protected override int ApiVersion => (int)1.0;

    protected override void MapEndpoints(IVersionedEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapDelete($"{Version}/customers/{{id}}", Delete)
            .WithOpenApi(DeleteCustomerConfiguration.ConfigureOpenApiOperation);
    }

    private async Task<DomainModels.Customer> Delete(Guid id, Persistence.Repositories.Customer customer,
        IMapper mapper,
        IMediator mediator)
    {
        var command = new Commands.Delete { Id = id };
        return await mediator.Send(command);
    }
}