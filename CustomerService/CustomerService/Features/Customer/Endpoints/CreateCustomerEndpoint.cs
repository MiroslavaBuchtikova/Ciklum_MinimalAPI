using CustomerService.ApiAutoregistration;
using CustomerService.Features.Customer.Commands;
using CustomerService.Features.Customer.DTOs;
using CustomerService.Features.Customer.SwaggerDocumentation;
using CustomerService.Filters;
using MediatR;
namespace CustomerService.Features.Customer.Endpoints;

public class CreateCustomerEndpoint : IApiRoute
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost($"{EndpointConfiguration.BaseApiPath}/customers", Create)
            .RequireAuthorization()
            .WithApiVersionSet(builder.NewApiVersionSet("Customers").Build())
            .HasApiVersion(1.0)
            .AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory)
            .WithOpenApi(CreateCustomerConfiguration.ConfigureOpenApiOperation);
    }
    private async Task<ResultDto> Create(CustomerRequestDto customerResponseDto, IMediator mediator)
    {
        var request = new CreateCustomerCommand(customerResponseDto);
        return await mediator.Send(request);
    }
}