using FluentValidation;

namespace CustomerService.Validators;

public class Customer : AbstractValidator<Features.Customer.DTOs.CustomerDto>
{
    public Customer()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name cannot be empty");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name cannot be empty");
        RuleFor(x => x.EmailAddress).EmailAddress().WithMessage("Email address is invalid");
    }
}