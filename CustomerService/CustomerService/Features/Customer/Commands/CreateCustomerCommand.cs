using CustomerService.Features.Customer.DTOs;
using MediatR;

namespace CustomerService.Features.Customer.Commands;

public record CreateCustomerCommand(CustomerRequestDto CustomerResponseDto) : IRequest<ResultDto>;