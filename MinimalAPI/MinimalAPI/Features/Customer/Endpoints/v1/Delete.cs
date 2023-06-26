using Asp.Versioning.Builder;
using AutoMapper;
using MediatR;
using MinimalAPI.ApiAutoregistration;
using MinimalAPI.Features.Customer.DTOs;
using MinimalAPI.Features.Customer.SwaggerDocumentation;

namespace MinimalAPI.Features.Customer.Endpoints.v1;

public class DeleteCustomer : BaseApiRoute
{
    protected override string RouteName => "Customers";
    protected override string Version => "v1";
    protected override int ApiVersion => 1;
    protected override bool RequireAuthorization => true;

    protected override void MapEndpoints(IVersionedEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapDelete($"{Version}/customers/{{id}}", Delete)
            .WithOpenApi(DeleteCustomerConfiguration.ConfigureOpenApiOperation);
    }

    private async Task<ResultDto> Delete(Guid id, Persistence.Repositories.CustomerRepository customerRepository, IMapper mapper,
        IMediator mediator)
    {
        var command = new Commands.DeleteCustomerCommand(id);
        return await mediator.Send(command);
    }


}