using AutoMapper;
using MediatR;
using MinimalAPI.MinimalAPI.API.Endpoints.Autoregistration;
using MinimalAPI.MinimalAPI.API.Filters;
using MinimalAPI.MinimalAPI.Application.Commands;
using MinimalAPI.MinimalAPI.Application.DTOs;
using MinimalAPI.MinimalAPI.Application.Queries;
using MinimalAPI.MinimalAPI.Persistence.Repositories;

namespace MinimalAPI.MinimalAPI.API.Endpoints.v1;

public class Customers : IApiRoute
{
    public void Register(WebApplication group)
    {
        var groupV1 = group.NewVersionedApi("Customers").HasApiVersion(1.0)
            .AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory).RequireAuthorization();

        groupV1.MapPost("v1/customers", CreateCustomer).AddEndpointFilter<LoggingEndpointFilter>();
        groupV1.MapPut("v1/customers/{id}", UpdateCustomer);
        groupV1.MapGet("v1/customers/{id}", GetCustomer);
        groupV1.MapGet("v1/customers", GetCustomers);
        groupV1.MapDelete("v1/customers/{id}", DeleteCustomer);
    }

    private async Task<IResult> CreateCustomer(CustomerDto customerDto, CustomerCommonRepository customerCommonRepository,
        IMapper mapper, IMediator mediator)
    {
        var request = new CreateCustomerCommand(customerDto);
        return await mediator.Send(request);
    }

    private async Task<IResult> UpdateCustomer(Guid id, CustomerDto customerDto,
        CustomerCommonRepository customerCommonRepository,
        IMapper mapper, IMediator mediator)
    {
        var command = new UpdateCustomerCommand { Id = id, CustomerDto = customerDto };
        var result = await mediator.Send(command);

        return result;
    }

    private async Task<IResult> DeleteCustomer(Guid id, CustomerCommonRepository customerCommonRepository, IMapper mapper, IMediator mediator)
    {
        var command = new DeleteCustomerCommand { Id = id };
        var result = await mediator.Send(command);

        return result;
    }

    private async Task<IResult> GetCustomer(Guid id, CustomerCommonRepository customerCommonRepository, IMapper mapper, IMediator mediator)
    {
        var query = new GetCustomerQuery { Id = id };
        var result = await mediator.Send(query);

        return Results.Ok(result);
    }

    private async Task<List<CustomerDto>> GetCustomers(CustomerCommonRepository customerCommonRepository, IMapper mapper, IMediator mediator)
    {
        var query = new GetCustomersQuery();
        var result = await mediator.Send(query);

        return result;
    }

    public class LoggingEndpointFilter : IEndpointFilter
    {
        public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var logger = context.HttpContext.RequestServices.GetService<ILogger<LoggingEndpointFilter>>();

            logger.LogInformation("Customer going to be created");
            var result = await next(context);
            logger.LogInformation("Customer created");

            return result;
        }
    }
}