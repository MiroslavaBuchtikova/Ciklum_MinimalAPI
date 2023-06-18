using AutoMapper;
using MediatR;
using MinimalAPI.MinimalAPI.Application.Commands;
using MinimalAPI.MinimalAPI.Persistence.Repositories;

namespace MinimalAPI.MinimalAPI.Application.Handlers;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, IResult>
{
    private readonly CustomerCommonRepository _customerRepository;
    private readonly IMapper _mapper;

    public UpdateCustomerCommandHandler(CustomerCommonRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IResult> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetById(request.Id);

        if (customer is null)
            return Results.NotFound();

        _mapper.Map(request.CustomerDto, customer);

        return Results.NoContent();
    }
}