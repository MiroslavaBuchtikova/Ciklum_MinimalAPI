namespace CustomerService.Features.Customer.DTOs.v2;

public record CustomerResponseDto(
    Guid Id,
    string FirstName,
    string LastName,
    string EmailAddress,
    Gender Gender
);