namespace CustomerService.Features.Customer.DTOs;

public record CustomerResponseDto(
    Guid Id,
    string FirstName,
    string LastName,
    string EmailAddress
);