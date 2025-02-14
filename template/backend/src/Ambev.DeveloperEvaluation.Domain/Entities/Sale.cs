using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        /// <summary>
        /// The unique identifier of the sale 
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Created date of the sale item
        /// </summary>
        public DateTime CreatedDate { get; private set; }

        /// <summary>
        /// The unique identifier of the customer (User Role=1)
        /// </summary>
        public Guid CustomerId { get; private set; }

        /// <summary>
        /// The unique identifier of the branch 
        /// </summary>
        public Guid BranchId { get; private set; }

        /// <summary>
        /// Canceled date of the sale 
        /// </summary>
        public DateTime? CanceledDate { get; private set; }

        /// <summary>
        /// List of sale items
        /// </summary>
        private readonly List<SaleItem> _saleItems = new();
        public IReadOnlyCollection<SaleItem> SaleItems => _saleItems.AsReadOnly();

        /// <summary>
        /// Total of sale item price without discount
        /// </summary>
        public decimal TotalWithoutDiscount => SaleItems.Sum(item => item.TotalPrice);

        /// <summary>
        /// Total Discount of the sale 
        /// </summary>
        public decimal TotalDiscount => SaleItems.Sum(item => item.Discount);

        /// <summary>
        /// Total of sale item price with discount
        /// </summary>
        public decimal TotalWithDiscount => TotalWithoutDiscount - TotalDiscount;


        /// <summary>
        /// Constructor for the Sale class
        /// </summary>
        public Sale()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            _saleItems = new();
        }

        /// <summary>
        /// Constructor with parameters to simplify object creation
        /// </summary>
        /// <param name="name">Name of the product</param>
        /// <param name="unitPrice">Unit price of the product</param>
        public Sale(Guid customerId, Guid branchId, List<SaleItem>? saleItems) : this()
        {
            CustomerId = customerId;
            BranchId = branchId;
            _saleItems = saleItems ?? new();

        }


        public SaleItem? AddOrUpdateSaleItem(int quantity, Product product)
        {
            SaleItem saleItem = null;
            if (quantity < 0)
                throw new ArgumentException("A quantidade não pode ser negativa.");
            if (quantity > 20)
                throw new InvalidOperationException("Uma venda não pode ter mais de 20 itens iguais.");
            // Verifica se o produto já existe na lista de itens da venda
            var existingSaleItem = _saleItems.FirstOrDefault(item => item.Product.Id.Equals(product.Id));

            if (existingSaleItem != null)
            {

                if (quantity.Equals(0))
                {
                    //remove sale item.
                    _saleItems.Remove(existingSaleItem);
                    return null;
                }
                else
                {
                    //update quantity.
                    existingSaleItem.UpdateQuantity(quantity);
                    return existingSaleItem;
                }
            }
            else
            {
                if (quantity.Equals(0))
                {
                    throw new InvalidOperationException("Sale item not found.");
                }

                // Add sale item.
                saleItem = new SaleItem(Id, quantity, product);
                _saleItems.Add(saleItem);
            }

            return saleItem;
        }


        /// <summary>
        /// Performs validation of the Sale entity using the SaleValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">Name length</list>
        /// 
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        /// <summary>
        /// Inactive the Sale.
        /// Changes the InactivatedDate to now.
        /// </summary>
        public void CancelSale()
        {
            CanceledDate = DateTime.UtcNow;

        }

    }
}
