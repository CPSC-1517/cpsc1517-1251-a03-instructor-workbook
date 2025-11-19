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
    public class RegionServices
    {
        private readonly IDbContextFactory<WestWindContext> _dbContextFactory;

        internal RegionServices(IDbContextFactory<WestWindContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Region?> GetRegionByRegionIdAsync(int regionId)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Regions
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.RegionID == regionId);
        }

        public async Task<List<Region>> GetAllRegionsAsync()
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Regions
                .AsNoTracking()
                .OrderBy(r => r.RegionDescription)
                .ToListAsync();
        }
    }
}
