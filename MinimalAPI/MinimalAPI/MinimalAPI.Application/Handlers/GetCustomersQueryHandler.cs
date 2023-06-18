using AutoMapper;
using MediatR;
using MinimalAPI.MinimalAPI.Application.DTOs;
using MinimalAPI.MinimalAPI.Application.Queries;
using MinimalAPI.MinimalAPI.Core.Entities;
using MinimalAPI.MinimalAPI.Persistence.Repositories;

namespace MinimalAPI.MinimalAPI.Application.Handlers;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerDto>>
{
    private readonly CustomerCommonRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomersQueryHandler(CustomerCommonRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<List<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAll();
        return customers.Select(_mapper.Map<CustomerDto>).ToList();
    }
}