using AutoMapper;
using MediatR;
using MinimalAPI.Features.Customer.DTOs;

namespace MinimalAPI.Features.Customer.Handlers;

public class Create : IRequestHandler<Commands.CreateCustomerCommand, ResultDto>
{
    private readonly Persistence.Repositories.CustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public Create(Persistence.Repositories.CustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<ResultDto> Handle(Commands.CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<MinimalAPI.Core.Entities.Customer>(command.CustomerDto);
        await _customerRepository.Add(customer);

        return _mapper.Map<ResultDto>(customer);
    }
}