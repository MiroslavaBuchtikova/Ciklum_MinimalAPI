using MediatR;

namespace MinimalAPI.MinimalAPI.Application.Queries;

public class GetCustomerQuery : IRequest<IResult>
{
    public Guid Id { get; set; }
}