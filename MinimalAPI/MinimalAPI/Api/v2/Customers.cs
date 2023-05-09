using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Autoregistration;
using MinimalAPI.Dtos;
using MinimalAPI.Entities;
using MinimalAPI.Filters;
using MinimalAPI.Persistence;

namespace MinimalAPI.Api.v2;

public class Customers : IApiRoute
{
    public void Register(WebApplication group)
    {
        var groupV1 = group.NewVersionedApi("Customers").HasApiVersion(2.0)
            .AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory).RequireAuthorization();

        groupV1.MapPost("v2/customers", CreateCustomer);
        groupV1.MapPut("v2/customers/{id}", UpdateCustomer);
        groupV1.MapGet("v2/customers/{id}", GetCustomer);
        groupV1.MapGet("v2/customers", GetCustomers);
        groupV1.MapDelete("v2/customers/{id}", DeleteCustomer);
    }

    private async Task<IResult> CreateCustomer(CustomerDto customerDto, CustomerDb customerDb,
        IMapper mapper)
    {
        var customer = mapper.Map<Customer>(customerDto);
        customerDb.Customers.Add(customer);
        await customerDb.SaveChangesAsync();
        
        return Results.Created($"/customers/{customer.Id}", customer);
    }

    private async Task<IResult> UpdateCustomer(Guid id, CustomerDto customerDto,
        CustomerDb customerDb,
        IMapper mapper)
    {
        var customer = await customerDb.Customers.FindAsync(id);

        if (customer is null) return Results.NotFound();

        mapper.Map(customerDto, customer);

        await customerDb.SaveChangesAsync();

        return Results.NoContent();
    }

    private async Task<IResult> DeleteCustomer(Guid id, CustomerDb customerDb, IMapper mapper)
    {
        if (await customerDb.Customers.FindAsync(id) is Customer customer)
        {
            customerDb.Customers.Remove(customer);
            await customerDb.SaveChangesAsync();
            return Results.Ok(mapper.Map<CustomerDto>(customer));
        }

        return Results.NotFound();
    }

    private async Task<IResult> GetCustomer(Guid id, CustomerDb customerDb, IMapper mapper)
    {
        var result = await customerDb.Customers.FindAsync(id)
            is Customer customer
            ? Results.Ok(mapper.Map<CustomerDto>(customer))
            : Results.NotFound();
        return result;
    }

    private async Task<List<CustomerDto>> GetCustomers(CustomerDb customerDb, IMapper mapper)
    {
        return await customerDb.Customers.Select(x => mapper.Map<CustomerDto>(x)).ToListAsync();
    }
}