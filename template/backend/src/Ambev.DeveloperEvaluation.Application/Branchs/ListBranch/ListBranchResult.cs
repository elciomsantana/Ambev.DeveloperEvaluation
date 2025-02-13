using Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Branchs.ListBranch;

/// <summary>
/// Response model for ListBranch operation
/// </summary>
public class ListBranchResult
{
    /// <summary>
    /// List of Branchs
    /// </summary>
    public List<GetBranchResult> ListOfBranchs { get; set; } = new();

}
