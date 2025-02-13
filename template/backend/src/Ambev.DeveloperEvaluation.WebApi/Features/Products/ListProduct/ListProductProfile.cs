using Ambev.DeveloperEvaluation.Application.Products.ListProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProduct;

/// <summary>
/// Profile for mapping ListProduct feature requests to commands
/// </summary>
public class ListProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListProduct feature
    /// </summary>
    public ListProductProfile()
    {
        CreateMap<Guid, Application.Products.ListProduct.ListProductCommand>()
            .ConstructUsing(id => new Application.Products.ListProduct.ListProductCommand());
        CreateMap<ListProductResult, ListProductResponse>();
    }
}
