using FluentValidation;

namespace Identity.Api.Models.User
{
    public class LoginFormModel 
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginFormModelValidator : AbstractValidator<LoginFormModel>
    {
        public LoginFormModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not valid.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
