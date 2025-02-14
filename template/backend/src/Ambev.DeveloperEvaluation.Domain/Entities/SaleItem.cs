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
    public class SaleItem : BaseEntity
    {
        /// <summary>
        /// The unique identifier of the sale item
        /// </summary>
        public Guid Id { get; private set; }
        /// <summary>
        /// The unique identifier of the sale
        /// </summary>
        public Guid SaleId { get; private set; }

        /// <summary>
        /// The unique identifier of the Prodduct
        /// </summary>
        public Guid ProductId { get; private set; }
        /// <summary>
        /// The Quantity of the product
        /// </summary>
        public int Quantity { get; private set; }

        // <summary>
        /// The Total price of the products
        /// </summary>
        public decimal TotalPrice { get; private set; }

        /// <summary>
        /// The discount of product price.
        /// </summary>
        public decimal Discount { get; private set; }

        /// <summary>
        /// The detail of discount
        /// </summary>
        public string DiscountDetail { get; private set; }

        /// <summary>
        /// Created date of the sale item
        /// </summary>
        public DateTime CreatedDate { get; private set; }

        /// <summary>
        /// Canceled date of the sale item
        /// </summary>
        public DateTime CanceledDate { get; private set; }

        /// <summary>
        /// Product relation
        /// </summary>
        public readonly Product Product;

        /// <summary>
        /// Constructor with parameters to simplify object creation
        /// </summary>
        /// <param name="saleId"> </param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        public SaleItem(Guid saleId, int quantity, Product product) : this()
        {
            if (quantity > 20)
                throw new InvalidOperationException("Não é permitido mais de 20 itens iguais.");
            Product = product;
            SaleId = saleId;
            ProductId = product.Id;
            Quantity = quantity;
            Calculate();
        }

        /// <summary>
        /// Constructor for the Product class
        /// </summary>
        public SaleItem()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Calculate the discount of amount
        /// </summary>
        /// 
        public void Calculate()
        {

            TotalPrice = Product.UnitPrice * Quantity;
            if (Quantity >= 10)
            {
                DiscountDetail = "20% Discount";
                Discount = TotalPrice * 0.2M;
            }
            else if (Quantity >= 4)
            {
                DiscountDetail = "10% Discount";
                Discount = TotalPrice * 0.1M;
            }
        }
        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity < 0)
                throw new ArgumentException("The quantity dont be negative.");

            Quantity = newQuantity;
        }

        /// <summary>
        /// Performs validation of the SaleItem entity using the SaleItemValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">Maximum quantity</list>
        ///   <list type="bullet">Empty quantity</list>
        /// <list type="bullet">Empty Product</list>
        /// 
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new SaleItemValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

    }
}
