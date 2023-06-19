using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MinimalAPI.Core.Exceptions;
using MinimalAPI.Persistence;

namespace MinimalAPI.Application.Features.Customer.Handlers;

public class Get : IRequestHandler<Queries.Get, DomainModels.Customer>
{
    private readonly Persistence.Repositories.Customer _customerRepository;
    private readonly IMapper _mapper;

    public Get(Persistence.Repositories.Customer customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<DomainModels.Customer> Handle(Queries.Get request, CancellationToken cancellationToken)
    {
        return await _customerRepository.GetById(request.Id) is Core.Entities.Customer customer ?
            _mapper.Map<DomainModels.Customer>(customer)
            : throw new CustomerNotFoundException();
        
    }
}