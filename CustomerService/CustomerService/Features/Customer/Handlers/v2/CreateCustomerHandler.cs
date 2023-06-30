using AutoMapper;
using CustomerService.Features.Customer.DTOs;
using CustomerService.Persistence.Repositories;
using MediatR;

namespace CustomerService.Features.Customer.Handlers.v2;

public class CreateCustomerHandler : IRequestHandler<Commands.v2.CreateCustomerCommand, ResultDto>
{
    private readonly CustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CreateCustomerHandler(CustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<ResultDto> Handle(Commands.v2.CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Core.Entities.CustomerEntity>(command.CustomerRequestDto);
        await _customerRepository.Add(customer);

        return _mapper.Map<ResultDto>(customer);
    }
}