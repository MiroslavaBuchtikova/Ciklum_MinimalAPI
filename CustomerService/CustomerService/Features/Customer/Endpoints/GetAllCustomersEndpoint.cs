using AutoMapper;
using CustomerService.ApiAutoregistration;
using CustomerService.Features.Customer.SwaggerDocumentation;
using CustomerService.Persistence.Repositories;
using MediatR;

namespace CustomerService.Features.Customer.Endpoints;

public class GetAllCustomersEndpoint : IApiRoute
{
    public void MapEndpoint(IEndpointRouteBuilder builder)
    {
        builder.MapGet($"{EndpointConfiguration.BaseApiPath}/customers", GetAll)

            .RequireAuthorization()
            .WithApiVersionSet(builder.NewApiVersionSet("Customers").Build())
            .HasApiVersion(1.0)
            .HasApiVersion(2.0)
            .WithOpenApi(GetCustomersConfiguration.ConfigureOpenApiOperation);
    }
    private async Task<List<DTOs.CustomerResponseDto>> GetAll(CustomerRepository customerRepository, IMapper mapper, IMediator mediator)
    {
        var query = new Queries.GetAll();
       return await mediator.Send(query);
    }

 
}