using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.ListBranch;

/// <summary>
/// Command for list Branchs
/// </summary>
public record ListBranchCommand : IRequest<ListBranchResult>
{
    
    /// <summary>
    /// Initializes a new instance of ListBranchCommand
    /// </summary>    
    public ListBranchCommand()
    {
      
    }
}
