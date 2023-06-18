using MediatR;
using MinimalAPI.MinimalAPI.Application.DTOs;

namespace MinimalAPI.MinimalAPI.Application.Commands;

public class UpdateCustomerCommand : IRequest<IResult>
{
    public Guid Id { get; set; }
    public CustomerDto CustomerDto { get; set; }
}