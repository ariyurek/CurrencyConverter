using FluentValidation;

namespace CurrencyConverter.Application.Features.Commands.AddCoinPrice
{
    public class AddCoinPriceCommandValidator : AbstractValidator<AddCoinPriceCommand>
    {
        public AddCoinPriceCommandValidator()
        {
            RuleFor(p => p.CoinCode)
                .NotEmpty().WithMessage("{CoinCode} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{CoinCode} must not exceed 50 characters.");

            RuleFor(p => p.Currency)
               .NotEmpty().WithMessage("{Currency} is required.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{Price} is required.")
                .GreaterThan(0).WithMessage("{Price} should be greater than zero.");
        }
    }
}
