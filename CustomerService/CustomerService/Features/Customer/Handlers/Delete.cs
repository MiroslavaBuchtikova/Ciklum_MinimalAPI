using AutoMapper;
using CustomerService.Persistence.Repositories;
using MediatR;
using MinimalAPI.Core.Exceptions;
using MinimalAPI.Features.Customer.DTOs;

namespace MinimalAPI.Features.Customer.Handlers;

public class Delete : IRequestHandler<Commands.DeleteCustomerCommand, ResultDto>
{
    private readonly CustomerRepository _customerRepositoryRepository;
    private readonly IMapper _mapper;

    public Delete(CustomerRepository customerRepositoryRepository, IMapper mapper)
    {
        _customerRepositoryRepository = customerRepositoryRepository;
        _mapper = mapper;
    }

    public async Task<ResultDto> Handle(Commands.DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        if (await _customerRepositoryRepository.GetById(request.Id) is Core.Entities.Customer customer)
        {
            await _customerRepositoryRepository.Delete(customer);
            return _mapper.Map<ResultDto>(customer);
        }

        throw new CustomerNotFoundException();
    }
}