using FluentValidation;

namespace CurrencyConverter.Application.Features.Queries
{
    public class GetCoinPriceListQueryValidator : AbstractValidator<GetCoinPriceListQuery>
    {
        public GetCoinPriceListQueryValidator()
        {
            RuleFor(p => p.CoinCode)
                .NotEmpty().WithMessage("{CoinCode} is required.")
                .NotNull()
                .MinimumLength(3).WithMessage("{CoinCode} minimum length should be 3.");
        }
    }
}
