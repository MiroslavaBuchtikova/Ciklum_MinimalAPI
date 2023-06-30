using AutoMapper;
using CustomerService.ApiAutoregistration;
using CustomerService.Features.Customer.SwaggerDocumentation;
using CustomerService.Persistence.Repositories;
using MediatR;

namespace CustomerService.Features.Customer.Endpoints;

public class GetCustomerEndpoint : IApiRoute
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet($"{EndpointConfiguration.BaseApiPath}/customers/{{id}}", Get)
            .RequireAuthorization()
            .WithApiVersionSet(builder.NewApiVersionSet("Customers").Build())
            .HasApiVersion(1.0)
            .HasApiVersion(2.0)
            .WithOpenApi(GetCustomerConfiguration.ConfigureOpenApiOperation);
    }

    private async Task<DTOs.CustomerResponseDto> Get(Guid id, CustomerRepository customerRepository,
        IMapper mapper,
        IMediator mediator)
    {
        var query = new Queries.Get { Id = id };
        return await mediator.Send(query);
    }
}