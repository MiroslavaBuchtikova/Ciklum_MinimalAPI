using AutoMapper;
using CustomerService.ApiAutoregistration;
using CustomerService.Features.Customer.DTOs;
using CustomerService.Features.Customer.SwaggerDocumentation;
using CustomerService.Persistence.Repositories;
using MediatR;

namespace CustomerService.Features.Customer.Endpoints;

public class UpdateCustomerEndpoint : IApiRoute
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPut($"{EndpointConfiguration.BaseApiPath}/customers/{{id}}", Update)
            .RequireAuthorization()
            .WithApiVersionSet(builder.NewApiVersionSet("Customers").Build())
            .HasApiVersion(1.0)
            .HasApiVersion(2.0)
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