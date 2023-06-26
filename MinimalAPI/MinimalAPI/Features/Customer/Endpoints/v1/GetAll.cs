using AutoMapper;
using MediatR;
using MinimalAPI.ApiAutoregistration;
using MinimalAPI.Features.Customer.SwaggerDocumentation;

namespace MinimalAPI.Features.Customer.Endpoints.v1;

public class GetAllCustomers : IApiRoute
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet($"{EndpointConfiguration.BaseApiPath}/customers", GetAll)

            .RequireAuthorization()
            .WithApiVersionSet(builder.NewApiVersionSet("Customers").Build())
            .HasApiVersion(1.0)
            .WithOpenApi(GetCustomersConfiguration.ConfigureOpenApiOperation);
    }
    private async Task<List<DTOs.CustomerDto>> GetAll(Persistence.Repositories.CustomerRepository customerRepository, IMapper mapper, IMediator mediator)
    {
        var query = new Queries.GetAll();
       return await mediator.Send(query);
    }

 
}