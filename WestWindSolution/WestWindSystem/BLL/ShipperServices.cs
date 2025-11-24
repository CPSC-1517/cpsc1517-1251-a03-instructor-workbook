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
    public class ShipperServices
    {
        private readonly IDbContextFactory<WestWindContext> _dbContextFactory;

        internal ShipperServices(IDbContextFactory<WestWindContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<List<Shipper>> GetAllShippers()
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Shippers
                        .OrderBy(s => s.CompanyName)
                        .ToListAsync();
        }
    }
}
