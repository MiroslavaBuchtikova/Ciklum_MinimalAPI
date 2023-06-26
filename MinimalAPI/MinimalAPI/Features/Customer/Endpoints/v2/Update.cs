using Asp.Versioning.Builder;
using AutoMapper;
using MediatR;
using MinimalAPI.ApiAutoregistration;
using MinimalAPI.Features.Customer.DTOs;
using MinimalAPI.Features.Customer.SwaggerDocumentation;

namespace MinimalAPI.Features.Customer.Endpoints.v2;

public class UpdateCustomer : BaseApiRoute
{
    protected override string RouteName => "Customers";
    protected override string Version => "v2";
    protected override int ApiVersion => 2;
    protected override bool RequireAuthorization => true;

    protected override void MapEndpoints(IVersionedEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPut($"{Version}/customers/{{id}}", Update)
            .WithOpenApi(UpdateCustomerConfiguration.ConfigureOpenApiOperation);
    }

    private async Task<ResultDto> Update(Guid id, CustomerDto customerDtoDto,
        Persistence.Repositories.CustomerRepository customerRepository,
        IMapper mapper, IMediator mediator)
    {
        var command = new Commands.UpdateCustomerCommand(id, customerDtoDto);
        return await mediator.Send(command);
    }
}