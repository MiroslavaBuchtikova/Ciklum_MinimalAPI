using CustomerService.Features.Customer.DTOs.v2;
using FluentValidation;

namespace CustomerService.Features.Customer.Validators.v2;

public class CustomerRequest : AbstractValidator<CustomerRequestDto>
{
    public CustomerRequest()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name cannot be empty");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name cannot be empty");
        RuleFor(x => x.EmailAddress).EmailAddress().WithMessage("Email address is invalid");
        RuleFor(x => x.Gender).NotEmpty().WithMessage("Gender is invalid");

    }
}