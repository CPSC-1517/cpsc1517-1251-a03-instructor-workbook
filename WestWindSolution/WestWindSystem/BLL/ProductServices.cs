using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    public class ProductServices
    {
        private readonly IDbContextFactory<WestWindContext> _dbContextFactory;

        internal ProductServices(IDbContextFactory<WestWindContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Product?> GetProductByProductIdAsync(int productID)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Products
                            .Include(p => p.Category)
                            .Include(p => p.Supplier)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(p => p.ProductID == productID);
        }

        public async Task<List<Product>> Product_GetByCategoryIDAsync(int categoryID)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Products
                    .Include(x => x.Supplier)
                    .Where(x => x.CategoryID == categoryID)
                    .OrderBy(x => x.ProductName)
                    .ToListAsync();
        }

        public async Task<int> AddProductAsync(Product newProduct)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();

            // Validate newProduct is not null
            if (newProduct == null)
            {
                throw new ArgumentNullException(nameof(newProduct),"Product information not submitted");
            }

            // Validate ProductID does not exists
            if (newProduct.ProductID > 0)
            {
                throw new ArgumentException($"There is already an product with ProductID {newProduct.ProductID}");
            }

            //  Validate SupplierID of product exists
            var supplierExists = await context.Suppliers
                .AnyAsync(s => s.SupplierID == newProduct.SupplierID);
            if (!supplierExists)
            {
                throw new ArgumentException($"SupplierID {newProduct.SupplierID} does not exists.");
            }

            // Validate CategoryID of product exists
            var categoryExists = await context.Categories
                .AnyAsync(c => c.CategoryID == newProduct.CategoryID);
            if (!categoryExists)
            {
                throw new ArgumentException($"Category {newProduct.CategoryID} does not exists.");
            }

            // Example of business rule:
            // 1) is not from the same supplier
            // 2) with the same product name
            // 3) having the same quantity per unit
            var duplicateProduct = await context.Products.AnyAsync(p =>
                                p.SupplierID == newProduct.SupplierID &&
                                p.ProductName == newProduct.ProductName &&
                                p.QuantityPerUnit == newProduct.QuantityPerUnit);
            if (duplicateProduct)
            {
                throw new ArgumentException($"{newProduct.ProductName} from {newProduct.Supplier.CompanyName} of size {newProduct.QuantityPerUnit} alread on file");
            }

            await context.Products.AddAsync(newProduct);
            await context.SaveChangesAsync();
            return newProduct.ProductID;
        }

        public async Task<int> UpdateProductAsync(Product updatedProduct)
        {
            // Validate updatedProduct is not null
            if (updatedProduct == null) 
            {
                throw new ArgumentNullException(nameof(updatedProduct),"Product information not submitted");
            }
   
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            // Validate updateProduct exists in database
            var productExists = await context.Products.AnyAsync(p => p.ProductID == updatedProduct.ProductID);
            if (!productExists)
            {
                throw new ArgumentException($"ProductID {updatedProduct.ProductID} does not exists.");
            }

            context.Products.Update(updatedProduct);
            return await context.SaveChangesAsync();

        }

        public async Task<int> DeleteProductAsync(int productId)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            // Valid productId exists
            var existingProduct = await context.Products.FirstOrDefaultAsync(p => p.ProductID == productId);
            if (existingProduct == null)
            {
                throw new ArgumentException($"ProductID {productId} does not exists.");
            }
            // Mark the Product as deleted changing the Discontinued flag to true
            existingProduct.Discontinued = true;
            // Update the Product
            context.Products.Update(existingProduct);
            return await context.SaveChangesAsync();
        }
    }
}
