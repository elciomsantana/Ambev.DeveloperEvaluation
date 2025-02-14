using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.InactiveSale;

/// <summary>
/// Profile for mapping InactiveSale feature requests to commands
/// </summary>
public class InactiveSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for InactiveSale feature
    /// </summary>
    public InactiveSaleProfile()
    {
        CreateMap<Guid, Application.Sales.InactiveSale.InactiveSaleCommand>()
            .ConstructUsing(id => new Application.Sales.InactiveSale.InactiveSaleCommand(id));
  
    }
}
