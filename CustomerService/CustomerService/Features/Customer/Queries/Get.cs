using MediatR;

namespace CustomerService.Features.Customer.Queries;

public class Get : IRequest<DTOs.CustomerResponseDto>
{
    public Guid Id { get; set; }
}