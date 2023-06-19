using MediatR;
using Microsoft.AspNetCore.Http;

namespace MinimalAPI.Application.Features.Customer.Queries;

public class Get : IRequest<DomainModels.Customer>
{
    public Guid Id { get; set; }
}