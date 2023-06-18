using MediatR;
using MinimalAPI.MinimalAPI.Application.DTOs;

namespace MinimalAPI.MinimalAPI.Application.Commands;

public class CreateCustomerCommand : IRequest<IResult>
{
    public CustomerDto CustomerDto { get; }

    public CreateCustomerCommand(CustomerDto customerDto)
    {
        CustomerDto = customerDto;
    }
}