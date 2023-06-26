using MediatR;

namespace CustomerService.Features.Customer.Queries;

public class Get : IRequest<DTOs.CustomerDto>
{
    public Guid Id { get; set; }
}