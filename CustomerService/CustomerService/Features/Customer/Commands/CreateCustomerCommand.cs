using CustomerService.Features.Customer.DTOs;
using MediatR;

namespace CustomerService.Features.Customer.Commands;

public record CreateCustomerCommand(CustomerDto CustomerDto) : IRequest<ResultDto>;