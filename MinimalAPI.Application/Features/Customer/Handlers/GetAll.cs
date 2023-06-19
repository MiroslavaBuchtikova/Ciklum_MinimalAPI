using AutoMapper;
using MediatR;

namespace MinimalAPI.Application.Features.Customer.Handlers;

public class GetAll : IRequestHandler<Queries.GetAll, List<DomainModels.Customer>>
{
    private readonly Persistence.Repositories.Customer _customerRepository;
    private readonly IMapper _mapper;

    public GetAll(Persistence.Repositories.Customer customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<List<global::MinimalAPI.Application.Features.Customer.DomainModels.Customer>> Handle(Queries.GetAll request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAll();
        return customers.Select(_mapper.Map<DomainModels.Customer>).ToList();
    }
}