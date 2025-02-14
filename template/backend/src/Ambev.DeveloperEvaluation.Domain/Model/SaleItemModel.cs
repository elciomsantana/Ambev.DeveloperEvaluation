using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Model
{
    public class SaleItemModel
    {
        /// <summary>
        /// The unique identifier of the Prodduct
        /// </summary>
        public Guid ProductId { get; set; }
        /// <summary>
        /// The Quantity of the product
        /// </summary>
        public int Quantity { get; set; }
    }
}
