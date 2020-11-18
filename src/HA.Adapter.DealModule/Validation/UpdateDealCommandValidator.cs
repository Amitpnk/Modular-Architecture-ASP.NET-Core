using FluentValidation;
using HA.Adapter.DealModule.Commands;

namespace HA.Adapter.DealModule.Validation
{
    public class UpdateDealCommandValidator : AbstractValidator<UpdateDealCommand>
    {
        public UpdateDealCommandValidator()
        {
            RuleFor(x => x.Id);
            RuleFor(x => x.Name);
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
