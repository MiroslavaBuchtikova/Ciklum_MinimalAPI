namespace CustomerService.Features.Customer.DTOs;

public record CustomerDto(
    string FirstName,
    string LastName,
    string EmailAddress
);