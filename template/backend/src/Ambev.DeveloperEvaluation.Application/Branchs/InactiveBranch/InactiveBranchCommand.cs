using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.InactiveBranch;

/// <summary>
/// Command for deleting a Branch
/// </summary>
public record InactiveBranchCommand : IRequest<InactiveBranchResponse>
{
    /// <summary>
    /// The unique identifier of the Branch to Inactive
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of InactiveBranchCommand
    /// </summary>
    /// <param name="id">The ID of the Branch to Inactive</param>
    public InactiveBranchCommand(Guid id)
    {
        Id = id;
    }
}
