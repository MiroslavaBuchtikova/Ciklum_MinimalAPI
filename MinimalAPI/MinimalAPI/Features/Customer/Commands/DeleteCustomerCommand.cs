using MediatR;
using MinimalAPI.Features.Customer.DTOs;

namespace MinimalAPI.Features.Customer.Commands;

public record DeleteCustomerCommand(Guid Id) : IRequest<ResultDto>;