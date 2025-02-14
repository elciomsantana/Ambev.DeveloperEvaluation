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
    public class Product : BaseEntity
    {
        /// <summary>
        /// The unique identifier of the Prodduct
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Name of the Product
        /// </summary>
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// Created date of the Product
        /// </summary>
        public DateTime CreatedDate { get; private set; }

        /// <summary>
        /// Product unit price
        /// </summary>
        public decimal UnitPrice { get; private set; }

        /// <summary>
        /// Inactivated date of the Product
        /// </summary>
        public DateTime? InactivatedDate { get; private set; }

        /// <summary>
        /// Constructor for the Product class
        /// </summary>
        public Product()
        {
            Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Constructor with parameters to simplify object creation
        /// </summary>
        /// <param name="name">Name of the product</param>
        /// <param name="unitPrice">Unit price of the product</param>
        public Product(string name, decimal unitPrice) : this()
        {
            Name = name;
            UnitPrice = unitPrice;
        }


        /// <summary>
        /// Performs validation of the Product entity using the ProductValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">Name length</list>
        /// <list type="bullet">UnitPrice minimum value</list>
        /// 
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        /// <summary>
        /// Inactive the Product.
        /// Changes the InactivatedDate to now.
        /// </summary>
        public void Inactive()
        {
            InactivatedDate = DateTime.UtcNow;

        }

    }
}
