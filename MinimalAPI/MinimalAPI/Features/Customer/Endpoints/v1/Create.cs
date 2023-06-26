using MediatR;
using MinimalAPI.ApiAutoregistration;
using MinimalAPI.Features.Customer.Commands;
using MinimalAPI.Features.Customer.DTOs;
using MinimalAPI.Features.Customer.SwaggerDocumentation;

namespace MinimalAPI.Features.Customer.Endpoints.v1;

public class CreateCustomer : IApiRoute
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapPost($"{EndpointConfiguration.BaseApiPath}/customers", Create)
            .RequireAuthorization()
            .WithApiVersionSet(builder.NewApiVersionSet("Customers").Build())
            .HasApiVersion(1.0)
            .WithOpenApi(CreateCustomerConfiguration.ConfigureOpenApiOperation);
    }

    private async Task<ResultDto> Create(DTOs.CustomerDto customerDto, IMediator mediator)
    {
        var request = new CreateCustomerCommand(customerDto);
        return await mediator.Send(request);
    }
}