using AutoMapper;
using CustomerService.Persistence.Repositories;
using MediatR;
using MinimalAPI.Core.Exceptions;

namespace MinimalAPI.Features.Customer.Handlers;

public class Get : IRequestHandler<Queries.Get, DTOs.CustomerDto>
{
    private readonly CustomerRepository _customerRepositoryRepository;
    private readonly IMapper _mapper;

    public Get(CustomerRepository customerRepositoryRepository, IMapper mapper)
    {
        _customerRepositoryRepository = customerRepositoryRepository;
        _mapper = mapper;
    }

    public async Task<DTOs.CustomerDto> Handle(Queries.Get request, CancellationToken cancellationToken)
    {
        return await _customerRepositoryRepository.GetById(request.Id) is Core.Entities.Customer customer ?
            _mapper.Map<DTOs.CustomerDto>(customer)
            : throw new CustomerNotFoundException();
        
    }
}