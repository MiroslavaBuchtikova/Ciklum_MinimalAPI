namespace CustomerService.Features.Customer.DTOs.v2;

public record CustomerDto
(
    string FirstName,
    string LastName,
    string EmailAddress,
    Gender Gender
);

public enum Gender
{
    Unknown,
    Male,
    Female
}