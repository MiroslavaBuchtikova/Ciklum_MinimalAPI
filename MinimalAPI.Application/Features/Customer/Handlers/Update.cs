using AutoMapper;
using MediatR;
using MinimalAPI.Core.Exceptions;

namespace MinimalAPI.Application.Features.Customer.Handlers;

public class Update : IRequestHandler<Commands.Update, DomainModels.Customer>
{
    private readonly Persistence.Repositories.Customer _customerRepository;
    private readonly IMapper _mapper;

    public Update(Persistence.Repositories.Customer customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<DomainModels.Customer> Handle(Commands.Update request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetById(request.Id);

        if (customer is null)
            throw new CustomerNotFoundException();

        await _customerRepository.Update(_mapper.Map(request.Customer, customer));
        
        return  _mapper.Map<DomainModels.Customer>(customer);
    }
}