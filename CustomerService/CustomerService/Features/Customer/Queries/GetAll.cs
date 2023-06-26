using MediatR;

namespace MinimalAPI.Features.Customer.Queries;

public class GetAll : IRequest<List<DTOs.CustomerDto>>
{
}