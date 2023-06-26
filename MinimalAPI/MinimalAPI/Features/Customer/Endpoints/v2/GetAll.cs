using Asp.Versioning.Builder;
using AutoMapper;
using MediatR;
using MinimalAPI.ApiAutoregistration;
using MinimalAPI.Features.Customer.SwaggerDocumentation;

namespace MinimalAPI.Features.Customer.Endpoints.v2;

public class GetAllCustomers : BaseApiRoute
{
    protected override string RouteName => "Customers";
    
    protected override string Version => "v2";
    protected override int ApiVersion => 2;
    protected override bool RequireAuthorization => true;
    
    protected override void MapEndpoints(IVersionedEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet($"{Version}/customers", GetAll)
            .WithOpenApi(GetCustomersConfiguration.ConfigureOpenApiOperation);
    }
    private async Task<List<DTOs.CustomerDto>> GetAll(Persistence.Repositories.CustomerRepository customerRepository, IMapper mapper, IMediator mediator)
    {
        var query = new Queries.GetAll();
        var result = await mediator.Send(query);

        return result;
    }

 
}