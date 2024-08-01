using FluentValidation;

namespace Identity.Api.Models.Token
{
    public class ValidateTokenRequestModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; } 
    }
    public class ValidateTokenRequestModelValidator : AbstractValidator<ValidateTokenRequestModel>
    {
        public ValidateTokenRequestModelValidator()
        {
            RuleFor(x => x.Token)
                .NotEmpty().WithMessage("Token is required.");

            RuleFor(x => x.RefreshToken)
                .NotEmpty().WithMessage("RefreshToken is required.");
        }
    }
}
