using AutoMapper;
using MediatR;

namespace MinimalAPI.Features.Customer.Handlers;

public class GetAll : IRequestHandler<Queries.GetAll, List<DTOs.CustomerDto>>
{
    private readonly Persistence.Repositories.CustomerRepository _customerRepositoryRepository;
    private readonly IMapper _mapper;

    public GetAll(Persistence.Repositories.CustomerRepository customerRepositoryRepository, IMapper mapper)
    {
        _customerRepositoryRepository = customerRepositoryRepository;
        _mapper = mapper;
    }

    public async Task<List<global::MinimalAPI.Features.Customer.DTOs.CustomerDto>> Handle(Queries.GetAll request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepositoryRepository.GetAll();
        return customers.Select(_mapper.Map<DTOs.CustomerDto>).ToList();
    }
}