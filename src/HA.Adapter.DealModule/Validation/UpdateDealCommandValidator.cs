using FluentValidation;
using HA.Adapter.DealModule.Commands;

namespace HA.Adapter.DealModule.Validation
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
