using HA.Application.DealFeature.Commands;
using FluentValidation;

namespace HA.Application.DealFeature.Validation
{
    public class UpdateDealCommandValidator : AbstractValidator<UpdateDealCommand>
    {
        public UpdateDealCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Description).NotEmpty()
                .NotEmpty().WithMessage("{PropertyName} is required.");

        }
    }
}
