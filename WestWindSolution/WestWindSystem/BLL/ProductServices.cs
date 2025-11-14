using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Product>> Product_GetByCategoryID(int categoryID)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Products
                    .Include(x => x.Supplier)
                    .Where(x => x.CategoryID == categoryID)
                    .OrderBy(x => x.ProductName)
                    .ToListAsync();
        }
    }
}
