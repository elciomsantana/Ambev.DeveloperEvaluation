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
    public class Branch : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; private set; }
        public DateTime? InactivatedDate { get; private set; }

        /// <summary>
        /// Constructor for the Product class
        /// </summary>
        public Branch()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Constructor with parameters to simplify object creation
        /// </summary>
        /// <param name="name">Name of the product</param>
        /// <param name="unitPrice">Unit price of the product</param>
        public Branch(string name) : this()
        {
            Name = name;

        }

        /// <summary>
        /// Performs validation of the Branch entity using the BranchValidator rules.
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
            var validator = new BranchValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        /// <summary>
        /// Inactive the Branch.
        /// Changes the InactivatedDate to now.
        /// </summary>
        public void Inactive()
        {
            InactivatedDate = DateTime.UtcNow;

        }

    }
}
