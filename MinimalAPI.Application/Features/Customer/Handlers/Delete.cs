using AutoMapper;
using MediatR;
using MinimalAPI.Core.Exceptions;

namespace MinimalAPI.Application.Features.Customer.Handlers;

public class Delete : IRequestHandler<Commands.Delete, DomainModels.Customer>
{
    private readonly Persistence.Repositories.Customer _customerRepository;
    private readonly IMapper _mapper;

    public Delete(Persistence.Repositories.Customer customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<DomainModels.Customer> Handle(Commands.Delete request, CancellationToken cancellationToken)
    {
        if (await _customerRepository.GetById(request.Id) is Core.Entities.Customer customer)
        {
            await _customerRepository.Delete(customer);
            return _mapper.Map<DomainModels.Customer>(customer);
        }

        throw new CustomerNotFoundException();
    }
}