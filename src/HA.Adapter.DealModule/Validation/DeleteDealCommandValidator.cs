using FluentValidation;
using HA.Adapter.DealModule.Commands;

namespace HA.Adapter.DealModule.Validation
{
    public class DeleteDealCommandValidator : AbstractValidator<DeleteDealCommand>
    {
        public DeleteDealCommandValidator()
        {
            RuleFor(v => v.DealId).NotEmpty();
        }
    }
}
