using FluentValidation;

namespace CustomerService.Features.Customer.Validators.v1;

public class CustomerRequest : AbstractValidator<DTOs.CustomerRequestDto>
{
    public CustomerRequest()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name cannot be empty");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name cannot be empty");
        RuleFor(x => x.EmailAddress).EmailAddress().WithMessage("Email address is invalid");
    }
}