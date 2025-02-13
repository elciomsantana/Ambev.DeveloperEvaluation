using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

namespace Ambev.DeveloperEvaluation.Application.Branchs.ListBranch;

/// <summary>
/// Profile for mapping between Branch entity and ListBranchResponse
/// </summary>
public class ListBranchProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListBranch operation
    /// </summary>
    public ListBranchProfile()
    {
        CreateMap<Branch, GetBranchResult>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
              .ForMember(dest => dest.InactivatedDate, opt => opt.MapFrom(src => src.InactivatedDate));

    }
}