using AutoMapper;
using MediatR;
using MinimalAPI.MinimalAPI.Application.DTOs;
using MinimalAPI.MinimalAPI.Application.Queries;
using MinimalAPI.MinimalAPI.Core.Entities;
using MinimalAPI.MinimalAPI.Persistence.Repositories;

namespace MinimalAPI.MinimalAPI.Application.Handlers;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, IResult>
{
    private readonly CustomerCommonRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomerQueryHandler(CustomerCommonRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IResult> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var result = await _customerRepository.GetById(request.Id)
            is Customer customer
            ? Results.Ok(_mapper.Map<CustomerDto>(customer))
            : Results.NotFound();
        
        return result;
    }
}