using MediatR;
using MinimalAPI.Features.Customer.DTOs;

namespace MinimalAPI.Features.Customer.Commands;

public record UpdateCustomerCommand(Guid Id, CustomerDto CustomerDto) : IRequest<ResultDto>;