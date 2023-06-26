using MediatR;
using MinimalAPI.Features.Customer.DTOs;

namespace MinimalAPI.Features.Customer.Commands;

public record CreateCustomerCommand(CustomerDto CustomerDto) : IRequest<ResultDto>;