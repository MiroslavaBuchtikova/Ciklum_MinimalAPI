using CustomerService.ApiAutoregistration;
using CustomerService.Features.Customer.DTOs;
using MediatR;
using CreateCustomerConfiguration = CustomerService.Features.Customer.SwaggerDocumentation.v2.CreateCustomerConfiguration;
using CustomerDto = CustomerService.Features.Customer.DTOs.v2.CustomerDto;

namespace CustomerService.Features.Customer.Endpoints.v2;

public class CreateCustomerEndpoint : IApiRoute
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost($"{EndpointConfiguration.BaseApiPath}/customers", Create)
            .RequireAuthorization()
            .WithApiVersionSet(builder.NewApiVersionSet("Customers").Build())
            .HasApiVersion(2.0)
            .WithOpenApi(CreateCustomerConfiguration.ConfigureOpenApiOperation);
    }

    private async Task<ResultDto> Create(CustomerDto customerDto, IMediator mediator)
    {
        var request = new CustomerService.Features.Customer.Commands.v2.CreateCustomerCommand(customerDto);
        return await mediator.Send(request);
    }
}