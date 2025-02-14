using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;

/// <summary>
/// Request model for getting a list of Sale
/// </summary>
public class ListSaleRequest
{
   
    /// <summary>
    /// The unique identifier of the User
    /// </summary>
     [JsonIgnore]
    public Guid UserId { get; set; }
}
