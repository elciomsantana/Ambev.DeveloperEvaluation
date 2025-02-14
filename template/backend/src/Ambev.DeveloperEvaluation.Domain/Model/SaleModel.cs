using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Model
{
    public class SaleModel
    {
        /// <summary>
        /// The unique identifier of the customer (User Role=1)
        /// </summary>
        [JsonIgnore]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// The unique identifier of the branch 
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// List of sale items
        /// </summary>
        public List<SaleItemModel> SaleItems { get; set; } = new();

    }
}
