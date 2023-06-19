using MediatR;

namespace MinimalAPI.Application.Features.Customer.Queries;

public class GetAll : IRequest<List<DomainModels.Customer>>
{
}