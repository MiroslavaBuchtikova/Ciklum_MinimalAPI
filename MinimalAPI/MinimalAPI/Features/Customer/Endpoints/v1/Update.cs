using Asp.Versioning.Builder;
using AutoMapper;
using MediatR;
using MinimalAPI.ApiAutoregistration;
using MinimalAPI.Features.Customer.DTOs;
using MinimalAPI.Features.Customer.SwaggerDocumentation;

namespace MinimalAPI.Features.Customer.Endpoints.v1;

public class UpdateCustomer : BaseApiRoute
{
    protected override string RouteName => "Customers";
    protected override string Version => "v1";
    protected override int ApiVersion => (int)1.0;
    protected override bool RequireAuthorization => true;

    protected override void MapEndpoints(IVersionedEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPut($"{Version}/customers/{{id}}", Update)
            .WithOpenApi(UpdateCustomerConfiguration.ConfigureOpenApiOperation);
    }

    private async Task<ResultDto> Update(Guid id, DTOs.CustomerDto customerDtoDto,
        Persistence.Repositories.CustomerRepository customerRepository,
        IMapper mapper, IMediator mediator)
    {
        var command = new Commands.UpdateCustomerCommand(id, customerDtoDto);
        return await mediator.Send(command);
    }
}