using AutoMapper;
using MediatR;
using MinimalAPI.Core.Exceptions;
using MinimalAPI.Features.Customer.DTOs;

namespace MinimalAPI.Features.Customer.Handlers;

public class Update : IRequestHandler<Commands.UpdateCustomerCommand, ResultDto
>
{
    private readonly Persistence.Repositories.CustomerRepository _customerRepositoryRepository;
    private readonly IMapper _mapper;

    public Update(Persistence.Repositories.CustomerRepository customerRepositoryRepository, IMapper mapper)
    {
        _customerRepositoryRepository = customerRepositoryRepository;
        _mapper = mapper;
    }

    public async Task<ResultDto> Handle(Commands.UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepositoryRepository.GetById(request.Id);

        if (customer is null)
            throw new CustomerNotFoundException();

        await _customerRepositoryRepository.Update(_mapper.Map(request.CustomerDto, customer));
        
        return  _mapper.Map<ResultDto>(customer);
    }
}