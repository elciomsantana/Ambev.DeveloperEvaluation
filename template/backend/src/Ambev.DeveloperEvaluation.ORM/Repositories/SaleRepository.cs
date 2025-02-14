using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Model;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of ISaleRepository using Entity Framework Core
    /// </summary>
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of SaleRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Sale in the database
        /// </summary>
        /// <param name="Sale">The Sale to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created Sale</returns>
        public async Task<Sale> CreateAsync(SaleModel saleModel, CancellationToken cancellationToken = default)
        {


            //Create Sale
            var sale = new Sale(saleModel.CustomerId, saleModel.BranchId, null);
            try
            {
                _context.Sales.Add(sale);
                await _context.SaveChangesAsync(cancellationToken);

                //Update items
                foreach (var item in saleModel.SaleItems)
                {
                    await UpdateAsync(new UpdateSaleModel
                    {
                        CustomerId = saleModel.CustomerId,
                        Quantity = item.Quantity,
                        ProductId = item.ProductId,
                        SaleId = sale.Id
                    }, cancellationToken);
                }

                sale = await GetByIdAsync(sale.Id, cancellationToken);

            }
            catch
            {
                _context.Sales.Remove(sale);
            }
            return sale;
        }

        /// <summary>
        /// Updates product list of Sale in the database
        /// </summary>
        /// <param name="saleRequest">The Sale to Update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Updated Sale</returns>
        public async Task<Sale> UpdateAsync(UpdateSaleModel saleRequest, CancellationToken cancellationToken = default)
        {
            // Get Sale
            var sale = await GetByIdAsync(saleRequest.SaleId, cancellationToken);

            if (sale == null)
            {
                throw new KeyNotFoundException("Sale not found.");
            }

            //check if the same user update are create the sale.
            if (!sale.CustomerId.Equals(saleRequest.CustomerId)) throw new UnauthorizedAccessException("Not your sale.");

            // Get Product
            var product = await _context.Products
                .FirstOrDefaultAsync(x => x.Id.Equals(saleRequest.ProductId), cancellationToken);

            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }

            //Update quantity of Sale Item
            var saleitem = sale.AddOrUpdateSaleItem(saleRequest.Quantity, product);

            _context.SaleItem.Add(saleitem);


            await _context.SaveChangesAsync(cancellationToken);

            return sale;
        }

        /// <summary>
        /// Retrieves a Sale by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the Sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Sale if found, null otherwise</returns>
        public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {

            var sale = await _context.Sales.Include(s => s.SaleItems).FirstOrDefaultAsync(o => o.Id.Equals(id), cancellationToken);

            return sale;
        }


        /// <summary>
        /// Retrieves a Sale by their unique identifier
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Sale if found, null otherwise</returns>
        public async Task<Sale[]> ListAsync(CancellationToken cancellationToken = default)
        {
            var list = await _context.Sales.Include(s => s.SaleItems).Where(o => !o.CanceledDate.HasValue).ToListAsync(cancellationToken);

            return list.ToArray();
        }

        /// <summary>
        /// Inactive a Sale from the database
        /// </summary>
        /// <param name="id">The unique identifier of the Sale to inactive</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the Sale was inactivated, false if not found</returns>
        public async Task<bool> InactiveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var Sale = await GetByIdAsync(id, cancellationToken);
            if (Sale == null)
                return false;

            Sale.CancelSale();
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

    }

}
