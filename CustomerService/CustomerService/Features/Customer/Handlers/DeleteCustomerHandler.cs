using AutoMapper;
using CustomerService.Core.Exceptions;
using CustomerService.Features.Customer.DTOs;
using CustomerService.Persistence.Repositories;
using MediatR;

namespace CustomerService.Features.Customer.Handlers;

public class DeleteCustomerHandler : IRequestHandler<Commands.DeleteCustomerCommand, ResultDto>
{
    private readonly CustomerRepository _customerRepositoryRepository;
    private readonly IMapper _mapper;

    public DeleteCustomerHandler(CustomerRepository customerRepositoryRepository, IMapper mapper)
    {
        _customerRepositoryRepository = customerRepositoryRepository;
        _mapper = mapper;
    }

    public async Task<ResultDto> Handle(Commands.DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        if (await _customerRepositoryRepository.GetById(request.Id) is Core.Entities.CustomerEntity customer)
        {
            await _customerRepositoryRepository.Delete(customer);
            return _mapper.Map<ResultDto>(customer);
        }

        throw new CustomerNotFoundException();
    }
}