using AutoMapper;
using CustomerService.Core.Exceptions;
using CustomerService.Persistence.Repositories;
using MediatR;

namespace CustomerService.Features.Customer.Handlers;

public class GetCustomerHandler : IRequestHandler<Queries.Get, DTOs.CustomerDto>
{
    private readonly CustomerRepository _customerRepositoryRepository;
    private readonly IMapper _mapper;

    public GetCustomerHandler(CustomerRepository customerRepositoryRepository, IMapper mapper)
    {
        _customerRepositoryRepository = customerRepositoryRepository;
        _mapper = mapper;
    }

    public async Task<DTOs.CustomerDto> Handle(Queries.Get request, CancellationToken cancellationToken)
    {
        return await _customerRepositoryRepository.GetById(request.Id) is Core.Entities.CustomerEntity customer ?
            _mapper.Map<DTOs.CustomerDto>(customer)
            : throw new CustomerNotFoundException();
        
    }
}