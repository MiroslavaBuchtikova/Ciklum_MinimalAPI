using AutoMapper;
using CustomerService.ApiAutoregistration;
using CustomerService.Features.Customer.DTOs;
using CustomerService.Features.Customer.SwaggerDocumentation;
using CustomerService.Persistence.Repositories;
using MediatR;

namespace CustomerService.Features.Customer.Endpoints;

public class DeleteCustomerEndpoint : IApiRoute
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapDelete($"{EndpointConfiguration.BaseApiPath}/customers/{{id}}", Delete)
            .RequireAuthorization()
            .WithApiVersionSet(builder.NewApiVersionSet("Customers").Build())
            .HasApiVersion(1.0)
            .HasApiVersion(2.0)
            .WithOpenApi(DeleteCustomerConfiguration.ConfigureOpenApiOperation);
    }

    private async Task<ResultDto> Delete(Guid id, CustomerRepository customerRepository,
        IMapper mapper,
        IMediator mediator)
    {
        var command = new Commands.DeleteCustomerCommand(id);
        return await mediator.Send(command);
    }
}