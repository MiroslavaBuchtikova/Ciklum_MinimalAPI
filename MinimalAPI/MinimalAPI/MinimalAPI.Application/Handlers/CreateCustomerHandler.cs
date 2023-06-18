using AutoMapper;
using MediatR;
using MinimalAPI.MinimalAPI.Application.Commands;
using MinimalAPI.MinimalAPI.Core.Entities;
using MinimalAPI.MinimalAPI.Persistence.Repositories;

namespace MinimalAPI.MinimalAPI.Application.Handlers;

public class CreateCustomerRequestHandler : IRequestHandler<CreateCustomerCommand, IResult>
{
    private readonly CustomerCommonRepository _customerCommonRepository;
    private readonly IMapper _mapper;

    public CreateCustomerRequestHandler(CustomerCommonRepository customerCommonRepository, IMapper mapper)
    {
        _customerCommonRepository = customerCommonRepository;
        _mapper = mapper;
    }

    public async Task<IResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(command.CustomerDto);
        await _customerCommonRepository.Add(customer);

        return Results.Created($"/customers/{customer.Id}", customer);
    }
}