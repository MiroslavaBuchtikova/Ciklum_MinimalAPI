using Asp.Versioning.Builder;
using AutoMapper;
using MediatR;
using MinimalAPI.ApiAutoregistration;
using MinimalAPI.Features.Customer.SwaggerDocumentation;

namespace MinimalAPI.Features.Customer.Endpoints.v1;

public class GetCustomer : BaseApiRoute
{
    protected override string RouteName => "Customers";
    protected override string Version => "v1";
    protected override int ApiVersion => 1;
    protected override bool RequireAuthorization => true;

    protected override void MapEndpoints(IVersionedEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet($"{Version}/customers/{{id}}", Get)
            .WithOpenApi(GetCustomerConfiguration.ConfigureOpenApiOperation);
    }

    private async Task<DTOs.CustomerDto> Get(Guid id, Persistence.Repositories.CustomerRepository customerRepository, IMapper mapper,
        IMediator mediator)
    {
        var query = new Queries.Get { Id = id };
        var result = await mediator.Send(query);

        return result;
    }

  
}