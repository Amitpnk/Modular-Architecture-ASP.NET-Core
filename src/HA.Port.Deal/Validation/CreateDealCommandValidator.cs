using HA.Application.DealFeature.Commands;
using HA.Application.DealFeature.Service;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace HA.Application.DealFeature.Validation
{
    public class CreateDealCommandValidator : AbstractValidator<CreateDealCommand>
    {
        private readonly IDealRepositoryAsync _groupRepositoryAsync;
        public CreateDealCommandValidator(IDealRepositoryAsync groupRepositoryAsync)
        {
            _groupRepositoryAsync = groupRepositoryAsync;

            RuleFor(x => x.Description).NotEmpty()
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Name).NotEmpty()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
            .MustAsync(IsUniqueName).WithMessage("{PropertyName} already exists.");
        }

        private async Task<bool> IsUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _groupRepositoryAsync.IsUniqueDealNameAsync(name);
        }
    }
}
