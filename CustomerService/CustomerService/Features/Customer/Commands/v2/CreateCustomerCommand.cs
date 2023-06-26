using CustomerService.Features.Customer.DTOs;
using MediatR;
using CustomerDto = CustomerService.Features.Customer.DTOs.v2.CustomerDto;

namespace CustomerService.Features.Customer.Commands.v2;

public record CreateCustomerCommand(CustomerDto CustomerDto) : IRequest<ResultDto>;