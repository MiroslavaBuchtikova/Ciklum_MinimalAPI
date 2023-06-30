namespace CustomerService.Features.Customer.DTOs.v2;

public record CustomerRequestDto
(
    string FirstName,
    string LastName,
    string EmailAddress,
    Gender Gender
);

public enum Gender
{
    Unknown = 0,
    Male = 1,
    Female = 2
}