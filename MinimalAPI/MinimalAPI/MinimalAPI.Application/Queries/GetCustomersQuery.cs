using MediatR;
using MinimalAPI.MinimalAPI.Application.DTOs;

namespace MinimalAPI.MinimalAPI.Application.Queries;

public class GetCustomersQuery : IRequest<List<CustomerDto>>
{
}