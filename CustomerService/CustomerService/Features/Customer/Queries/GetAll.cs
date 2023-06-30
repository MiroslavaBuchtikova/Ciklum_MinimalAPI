using MediatR;

namespace CustomerService.Features.Customer.Queries;

public class GetAll : IRequest<List<DTOs.CustomerResponseDto>>
{
}