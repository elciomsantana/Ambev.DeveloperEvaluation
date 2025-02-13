

using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.InactiveBranch;

/// <summary>
/// Profile for mapping InactiveBranch feature requests to commands
/// </summary>
public class InactiveBranchProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for InactiveBranch feature
    /// </summary>
    public InactiveBranchProfile()
    {
        CreateMap<Guid, Application.Branchs.InactiveBranch.InactiveBranchCommand>()
            .ConstructUsing(id => new Application.Branchs.InactiveBranch.InactiveBranchCommand(id));
  
    }
}
