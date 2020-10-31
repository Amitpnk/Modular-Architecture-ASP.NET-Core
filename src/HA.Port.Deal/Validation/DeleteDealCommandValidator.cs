using HA.Application.DealFeature.Commands;
using FluentValidation;

namespace HA.Application.DealFeature.Validation
{
    public class DeleteDealCommandValidator : AbstractValidator<DeleteDealCommand>
    {
        public DeleteDealCommandValidator()
        {
            RuleFor(v => v.DealId)
                .NotEmpty().WithMessage("{PropertyName} is required.");

        }
    }
}
