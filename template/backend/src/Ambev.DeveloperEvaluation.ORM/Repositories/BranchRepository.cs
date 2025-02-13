using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of IBranchRepository using Entity Framework Core
    /// </summary>
    public class BranchRepository : IBranchRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of BranchRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public BranchRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Branch in the database
        /// </summary>
        /// <param name="Branch">The Branch to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created Branch</returns>
        public async Task<Branch> CreateAsync(Branch Branch, CancellationToken cancellationToken = default)
        {
            await _context.Branchs.AddAsync(Branch, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Branch;
        }

        /// <summary>
        /// Retrieves a Branch by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the Branch</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Branch if found, null otherwise</returns>
        public async Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Branchs.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }


        /// <summary>
        /// Retrieves a Branch by their unique identifier
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Branch if found, null otherwise</returns>
        public async Task<Branch[]> ListAsync(CancellationToken cancellationToken = default)
        {
   
            var list = await _context.Branchs.Where(o => !o.InactivatedDate.HasValue).ToListAsync(cancellationToken);
            return list.ToArray();
        }

        /// <summary>
        /// Inactive a Branch from the database
        /// </summary>
        /// <param name="id">The unique identifier of the Branch to inactive</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the Branch was inactivated, false if not found</returns>
        public async Task<bool> InactiveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var branch = await GetByIdAsync(id, cancellationToken);
            if (branch == null)
                return false;

            branch.Inactive();
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

    }

}
