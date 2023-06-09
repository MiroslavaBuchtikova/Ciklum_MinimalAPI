using CustomerService.Features.Customer.DTOs;
using MediatR;

namespace CustomerService.Features.Customer.Commands;

public record DeleteCustomerCommand(Guid Id) : IRequest<ResultDto>;