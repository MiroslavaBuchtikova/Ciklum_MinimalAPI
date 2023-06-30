using AutoMapper;
using CustomerService.Persistence.Repositories;
using MediatR;

namespace CustomerService.Features.Customer.Handlers;

public class GetAllCustomersHandler : IRequestHandler<Queries.GetAll, List<DTOs.CustomerResponseDto>>
{
    private readonly CustomerRepository _customerRepositoryRepository;
    private readonly IMapper _mapper;

    public GetAllCustomersHandler(CustomerRepository customerRepositoryRepository, IMapper mapper)
    {
        _customerRepositoryRepository = customerRepositoryRepository;
        _mapper = mapper;
    }

    public async Task<List<DTOs.CustomerResponseDto>> Handle(Queries.GetAll request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepositoryRepository.GetAll();
        return customers.Select(_mapper.Map<DTOs.CustomerResponseDto>).ToList();
    }
}