using MediatR;

namespace MinimalAPI.Features.Customer.Queries;

public class Get : IRequest<DTOs.CustomerDto>
{
    public Guid Id { get; set; }
}