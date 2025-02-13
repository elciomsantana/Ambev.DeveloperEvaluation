using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branchs.InactiveBranch;

/// <summary>
/// Validator for InactiveBranchCommand
/// </summary>
public class InactiveBranchValidator : AbstractValidator<InactiveBranchCommand>
{
    /// <summary>
    /// Initializes validation rules for InactiveBranchCommand
    /// </summary>
    public InactiveBranchValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Branch ID is required");
    }
}
