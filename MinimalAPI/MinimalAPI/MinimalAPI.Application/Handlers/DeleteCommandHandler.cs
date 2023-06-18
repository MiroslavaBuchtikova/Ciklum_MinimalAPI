using AutoMapper;
using MediatR;
using MinimalAPI.MinimalAPI.Application.Commands;
using MinimalAPI.MinimalAPI.Application.DTOs;
using MinimalAPI.MinimalAPI.Core.Entities;
using MinimalAPI.MinimalAPI.Persistence.Repositories;

namespace MinimalAPI.MinimalAPI.Application.Handlers;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, IResult>
{
    private readonly CustomerCommonRepository _customerRepository;
    private readonly IMapper _mapper;

    public DeleteCustomerCommandHandler(CustomerCommonRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IResult> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        if (await _customerRepository.GetById(request.Id) is Customer customer)
        {
            await _customerRepository.Delete(customer);
            return Results.Ok(_mapper.Map<CustomerDto>(customer));
        }

        return Results.NotFound();
    }
}