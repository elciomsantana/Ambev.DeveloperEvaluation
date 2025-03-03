using Ambev.DeveloperEvaluation.Application.Sales.ListSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;

/// <summary>
/// Profile for mapping ListSale feature requests to commands
/// </summary>
public class ListSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListSale feature
    /// </summary>
    public ListSaleProfile()
    {
        CreateMap<Guid, Application.Sales.ListSale.ListSaleCommand>()
            .ConstructUsing(id => new Application.Sales.ListSale.ListSaleCommand());
        CreateMap<ListSaleResult, ListSaleResponse>();
    }
}
