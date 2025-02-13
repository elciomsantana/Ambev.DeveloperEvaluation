using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.InactiveBranch;

/// <summary>
/// Validator for InactiveBranchRequest
/// </summary>
public class InactiveBranchRequestValidator : AbstractValidator<InactiveBranchRequest>
{
    /// <summary>
    /// Initializes validation rules for InactiveBranchRequest
    /// </summary>
    public InactiveBranchRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Branch ID is required");
    }
}
