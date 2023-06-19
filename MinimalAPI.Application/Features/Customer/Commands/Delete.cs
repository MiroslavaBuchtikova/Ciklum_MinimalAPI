using MediatR;

namespace MinimalAPI.Application.Features.Customer.Commands;

public class Delete : IRequest<DomainModels.Customer>
{
    public Guid Id { get; set; }
}