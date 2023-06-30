using CustomerService.ApiAutoregistration;
using CustomerService.Features.Customer.DTOs;
using CustomerService.Filters;
using MediatR;
using CreateCustomerConfiguration = CustomerService.Features.Customer.SwaggerDocumentation.v2.CreateCustomerConfiguration;
using CreateCustomerCommand = CustomerService.Features.Customer.Commands.v2.CreateCustomerCommand;
using CustomerRequestDto = CustomerService.Features.Customer.DTOs.v2.CustomerRequestDto;

namespace CustomerService.Features.Customer.Endpoints.v2;

public class CreateCustomerEndpoint : IApiRoute
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost($"{EndpointConfiguration.BaseApiPath}/customers", Create)
            .RequireAuthorization()
            .WithApiVersionSet(builder.NewApiVersionSet("Customers").Build())
            .HasApiVersion(2.0)
            .AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory)
            .WithOpenApi(CreateCustomerConfiguration.ConfigureOpenApiOperation);
    }

    private async Task<ResultDto> Create(CustomerRequestDto customerRequestDto, IMediator mediator)
    {
        var request = new CreateCustomerCommand(customerRequestDto);
        return await mediator.Send(request);
    }
}