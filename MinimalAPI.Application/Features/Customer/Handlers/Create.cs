using AutoMapper;
using MediatR;

namespace MinimalAPI.Application.Features.Customer.Handlers;

public class Create : IRequestHandler<Commands.Create, DomainModels.Customer>
{
    private readonly Persistence.Repositories.Customer _customer;
    private readonly IMapper _mapper;

    public Create(Persistence.Repositories.Customer customer, IMapper mapper)
    {
        _customer = customer;
        _mapper = mapper;
    }

    public async Task<DomainModels.Customer> Handle(Commands.Create command, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<MinimalAPI.Core.Entities.Customer>(command.Customer);
        await _customer.Add(customer);

        return command.Customer;
    }
}