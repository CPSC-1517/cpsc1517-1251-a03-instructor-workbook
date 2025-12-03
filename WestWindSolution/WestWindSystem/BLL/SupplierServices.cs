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
    public class SupplierServices
    {
        private readonly IDbContextFactory<WestWindContext> _dbContextFactory;

        internal SupplierServices(IDbContextFactory<WestWindContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Suppliers
                .OrderBy(s => s.CompanyName)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
