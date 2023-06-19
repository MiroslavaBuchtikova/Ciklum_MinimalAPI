using MediatR;

namespace MinimalAPI.Application.Features.Customer.Commands;

public class Update : IRequest<DomainModels.Customer>
{
    public Guid Id { get; set; }
    public DomainModels.Customer Customer { get; set; }
}