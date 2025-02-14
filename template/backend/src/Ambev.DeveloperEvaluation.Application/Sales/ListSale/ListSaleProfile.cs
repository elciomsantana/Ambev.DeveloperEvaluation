using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Profile for mapping between Sale entity and ListSaleResponse
/// </summary>
public class ListSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListSale operation
    /// </summary>
    public ListSaleProfile()
    {
        CreateMap<Sale, GetSaleResult>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                     .ForMember(dest => dest.BranchId, opt => opt.MapFrom(src => src.BranchId))
              .ForMember(dest => dest.CanceledDate, opt => opt.MapFrom(src => src.CanceledDate))
              .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
              .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                 .ForMember(dest => dest.SaleItems, opt => opt.MapFrom(src => src.SaleItems))
                 .ForMember(dest => dest.TotalWithoutDiscount, opt => opt.MapFrom(src => src.TotalWithoutDiscount))
                 .ForMember(dest => dest.TotalDiscount, opt => opt.MapFrom(src => src.TotalDiscount))
                 .ForMember(dest => dest.TotalWithDiscount, opt => opt.MapFrom(src => src.TotalWithDiscount));
             

    }
}