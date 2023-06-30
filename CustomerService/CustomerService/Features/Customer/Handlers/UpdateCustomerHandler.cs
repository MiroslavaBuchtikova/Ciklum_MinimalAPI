using AutoMapper;
using CustomerService.Core.Exceptions;
using CustomerService.Features.Customer.DTOs;
using CustomerService.Persistence.Repositories;
using MediatR;

namespace CustomerService.Features.Customer.Handlers;

public class UpdateCustomerHandler : IRequestHandler<Commands.UpdateCustomerCommand, ResultDto
>
{
    private readonly CustomerRepository _customerRepositoryRepository;
    private readonly IMapper _mapper;

    public UpdateCustomerHandler(CustomerRepository customerRepositoryRepository, IMapper mapper)
    {
        _customerRepositoryRepository = customerRepositoryRepository;
        _mapper = mapper;
    }

    public async Task<ResultDto> Handle(Commands.UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepositoryRepository.GetById(request.Id);

        if (customer is null)
            throw new CustomerNotFoundException();

        await _customerRepositoryRepository.Update(_mapper.Map(request.CustomerResponseDto, customer));
        
        return  _mapper.Map<ResultDto>(customer);
    }
}