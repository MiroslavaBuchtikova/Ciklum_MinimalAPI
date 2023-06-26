using AutoMapper;
using CustomerService.Persistence.Repositories;
using MediatR;
using MinimalAPI.ApiAutoregistration;
using MinimalAPI.Features.Customer.DTOs;
using MinimalAPI.Features.Customer.SwaggerDocumentation;

namespace MinimalAPI.Features.Customer.Endpoints.v1;

public class UpdateCustomer : IApiRoute
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPut($"{EndpointConfiguration.BaseApiPath}/customers/{{id}}", Update)
            .RequireAuthorization()
            .WithApiVersionSet(builder.NewApiVersionSet("Customers").Build())
            .HasApiVersion(1.0)
            .WithOpenApi(UpdateCustomerConfiguration.ConfigureOpenApiOperation);
    }

    private async Task<ResultDto> Update(Guid id, DTOs.CustomerDto customerDtoDto,
        CustomerRepository customerRepository,
        IMapper mapper, IMediator mediator)
    {
        var command = new Commands.UpdateCustomerCommand(id, customerDtoDto);
        return await mediator.Send(command);
    }
}