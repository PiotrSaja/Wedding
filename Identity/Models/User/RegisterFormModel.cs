using FluentValidation;

namespace Identity.Api.Models.User
{
    public class RegisterFormModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
    public class RegisterFormModelValidator : AbstractValidator<RegisterFormModel>
    {
        public RegisterFormModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not valid.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(x => x.RepeatPassword)
                .NotEmpty().WithMessage("Repeat Password is required.")
                .Equal(x => x.Password).WithMessage("Passwords do not match.");
        }
    }
}
