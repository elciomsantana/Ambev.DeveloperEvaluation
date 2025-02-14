using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Command for list Sales
/// </summary>
public record ListSaleCommand : IRequest<ListSaleResult>
{
    
    /// <summary>
    /// Initializes a new instance of ListSaleCommand
    /// </summary>    
    public ListSaleCommand()
    {
      
    }
}
