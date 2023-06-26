using AutoMapper;
using MediatR;
using MinimalAPI.ApiAutoregistration;
using MinimalAPI.Features.Customer.DTOs;
using MinimalAPI.Features.Customer.SwaggerDocumentation;

namespace MinimalAPI.Features.Customer.Endpoints.v1;

public class DeleteCustomer : IApiRoute
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapDelete($"{EndpointConfiguration.BaseApiPath}/customers/{{id}}", Delete)
            .RequireAuthorization()
            .WithApiVersionSet(builder.NewApiVersionSet("Customers").Build())
            .HasApiVersion(1.0)
            .WithOpenApi(DeleteCustomerConfiguration.ConfigureOpenApiOperation);
    }

    private async Task<ResultDto> Delete(Guid id, Persistence.Repositories.CustomerRepository customerRepository,
        IMapper mapper,
        IMediator mediator)
    {
        var command = new Commands.DeleteCustomerCommand(id);
        return await mediator.Send(command);
    }
}