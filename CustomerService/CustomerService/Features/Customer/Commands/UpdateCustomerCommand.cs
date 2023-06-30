using CustomerService.Features.Customer.DTOs;
using MediatR;

namespace CustomerService.Features.Customer.Commands;

public record UpdateCustomerCommand(Guid Id, CustomerRequestDto CustomerResponseDto) : IRequest<ResultDto>;