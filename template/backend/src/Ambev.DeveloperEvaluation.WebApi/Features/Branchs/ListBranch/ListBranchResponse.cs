using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranch;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.ListBranch;

/// <summary>
/// API response model for ListBranch operation
/// </summary>
public class ListBranchResponse
{

    /// <summary>
    /// List of Branchs
    /// </summary>
    public GetBranchResponse[] ListOfBranchs { get; set; }

  

}
