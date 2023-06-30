namespace CustomerService.Features.Customer.DTOs;

public record CustomerRequestDto(
    string FirstName,
    string LastName,
    string EmailAddress
);