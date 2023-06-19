using MediatR;

namespace MinimalAPI.Application.Features.Customer.Commands;

public class Create : IRequest<DomainModels.Customer>
{
    public DomainModels.Customer Customer { get; }

    public Create(DomainModels.Customer customer)
    {
        Customer = customer;
    }
}