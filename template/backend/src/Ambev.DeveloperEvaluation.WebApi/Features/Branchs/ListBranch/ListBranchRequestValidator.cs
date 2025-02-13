using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.ListBranch;

/// <summary>
/// Validator for ListBranchRequest
/// </summary>
public class ListBranchRequestValidator : AbstractValidator<ListBranchRequest>
{
    /// <summary>
    /// Initializes validation rules for ListBranchRequest
    /// </summary>
    public ListBranchRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Branch ID is required");
    }
}
