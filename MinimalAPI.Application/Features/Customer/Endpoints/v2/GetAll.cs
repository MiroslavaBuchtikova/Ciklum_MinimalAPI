using Asp.Versioning.Builder;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using MinimalAPI.Application.ApiAutoregistration;
using MinimalAPI.Application.Features.Customer.SwaggerDocumentation;

namespace MinimalAPI.Application.Features.Customer.Endpoints.v2;

public class GetAllCustomers : BaseApiRoute
{
    protected override string RouteName => "Customers";
    
    protected override string Version => "v2";
    protected override int ApiVersion => (int)2.0;
    
    protected override void MapEndpoints(IVersionedEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet($"{Version}/customers", GetAll)
            .WithOpenApi(GetCustomersConfiguration.ConfigureOpenApiOperation);
    }
    private async Task<List<DomainModels.Customer>> GetAll(Persistence.Repositories.Customer customer, IMapper mapper, IMediator mediator)
    {
        var query = new Queries.GetAll();
        var result = await mediator.Send(query);

        return result;
    }
}