using MediatR;

namespace MinimalAPI.MinimalAPI.Application.Commands;

public class DeleteCustomerCommand : IRequest<IResult>
{
    public Guid Id { get; set; }
}