using AutoMapper;
using MediatR;
using MinimalAPI.ApiAutoregistration;
using MinimalAPI.Features.Customer.SwaggerDocumentation;

namespace MinimalAPI.Features.Customer.Endpoints.v1;

public class GetCustomer : IApiRoute
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet($"{EndpointConfiguration.BaseApiPath}/customers/{{id}}", Get)
            .RequireAuthorization()
            .WithApiVersionSet(builder.NewApiVersionSet("Customers").Build())
            .HasApiVersion(1.0)
            .WithOpenApi(GetCustomerConfiguration.ConfigureOpenApiOperation);
    }

    private async Task<DTOs.CustomerDto> Get(Guid id, Persistence.Repositories.CustomerRepository customerRepository,
        IMapper mapper,
        IMediator mediator)
    {
        var query = new Queries.Get { Id = id };
        return await mediator.Send(query);
    }
}