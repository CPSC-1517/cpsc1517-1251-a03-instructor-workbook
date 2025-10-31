using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL1
{
    public class CategoryServices
    {
        private readonly IDbContextFactory<WestWindContext> _dbContextFactory;

        internal CategoryServices(IDbContextFactory<WestWindContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<List<Category>> Category_GetAllAsync()
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context
                            .Categories
                            .OrderBy(c => c.CategoryName)
                            .ToListAsync();
        }

    }
}
