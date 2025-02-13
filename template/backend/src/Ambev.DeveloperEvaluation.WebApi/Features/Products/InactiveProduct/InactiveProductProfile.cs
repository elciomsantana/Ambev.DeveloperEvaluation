

using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.InactiveProduct;

/// <summary>
/// Profile for mapping InactiveProduct feature requests to commands
/// </summary>
public class InactiveProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for InactiveProduct feature
    /// </summary>
    public InactiveProductProfile()
    {
        CreateMap<Guid, Application.Products.InactiveProduct.InactiveProductCommand>()
            .ConstructUsing(id => new Application.Products.InactiveProduct.InactiveProductCommand(id));
  
    }
}
