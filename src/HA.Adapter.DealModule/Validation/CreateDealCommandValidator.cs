using FluentValidation;
using HA.Adapter.DealModule.Commands;

namespace HA.Adapter.DealModule.Validation
{
    public class CreateDealCommandValidator : AbstractValidator<CreateDealCommand>
    {
        public CreateDealCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty()
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Name).NotEmpty()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}
