namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;

/// <summary>
/// Represents the response returned after successfully creating a new Branch.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created Branch,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateBranchResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created Branch.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created Branch in the system.</value>
    public Guid Id { get; set; }

    /// <summary>
    /// Name of the Branch
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Created date of the Branch
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Inactivated  date of the Branch
    /// </summary>
    public DateTime? InactivatedDate { get; private set; }


}
