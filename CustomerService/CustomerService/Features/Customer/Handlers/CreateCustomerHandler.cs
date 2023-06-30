using AutoMapper;
using CustomerService.Features.Customer.DTOs;
using CustomerService.Persistence.Repositories;
using MediatR;

namespace CustomerService.Features.Customer.Handlers;

public class CreateCustomerHandler : IRequestHandler<Commands.CreateCustomerCommand, ResultDto>
{
    private readonly CustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CreateCustomerHandler(CustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<ResultDto> Handle(Commands.CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Core.Entities.CustomerEntity>(command.CustomerResponseDto);
        await _customerRepository.Add(customer);

        return _mapper.Map<ResultDto>(customer);
    }
}