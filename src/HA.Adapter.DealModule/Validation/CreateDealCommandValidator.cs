using FluentValidation;
using HA.Adapter.DealModule.Commands;

namespace HA.Adapter.DealModule.Validation
{
    public class CreateDealCommandValidator : AbstractValidator<CreateDealCommand>
    {
        private const int maxLength = 50;
        public CreateDealCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Name).NotEmpty()
                .MaximumLength(maxLength);
        }
    }
}
