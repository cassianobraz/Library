using FluentValidation;
using TechLibrary.Communication.Requests;

namespace TechLibrary.Api.UseCases.Users.Register;

public class RegisterUserValidator : AbstractValidator<RequestUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(Request => Request.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(Request => Request.Email).EmailAddress().WithMessage("Email not is valid.");
        RuleFor(Request => Request.Password).NotEmpty().WithMessage("Password is required.");
        When(request => string.IsNullOrEmpty(request.Password) == false, () =>
        {
            RuleFor(request => request.Password.Length).GreaterThanOrEqualTo(6).WithMessage("Password must be longer than 6 characters.");
        });
    }
}
