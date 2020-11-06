using FluentValidation;
using HA.Adapter.DealModule.Commands;
//using HA.Adapter.DealModule.Service;

namespace HA.Adapter.DealModule.Validation
{
    public class CreateDealCommandValidator : AbstractValidator<CreateDealCommand>
    {
        //private readonly IDealRepositoryAsync _dealRepositoryAsync;
        public CreateDealCommandValidator()//(IDealRepositoryAsync dealRepositoryAsync)
        {
            //_dealRepositoryAsync = dealRepositoryAsync;

            RuleFor(x => x.Description).NotEmpty()
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Name).NotEmpty()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            //.MustAsync(IsUniqueName).WithMessage("{PropertyName} already exists.");
        }

        //private async Task<bool> IsUniqueName(string name, CancellationToken cancellationToken)
        //{
        //    return await _dealRepositoryAsync.IsUniqueDealNameAsync(name);
        //}
    }
}
