using CustomerService.Features.Customer.DTOs;
using MediatR;
using CustomerRequestDto = CustomerService.Features.Customer.DTOs.v2.CustomerRequestDto;

namespace CustomerService.Features.Customer.Commands.v2;

public record CreateCustomerCommand(CustomerRequestDto CustomerRequestDto) : IRequest<ResultDto>;