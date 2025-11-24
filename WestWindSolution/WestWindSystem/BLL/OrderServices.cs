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
    public class OrderServices
    {
        private readonly IDbContextFactory<WestWindContext> _dbContextFactory;

        internal OrderServices(IDbContextFactory<WestWindContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<List<Order>> FindLast100UnshippedOrders()
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Orders
                        //.Where(o => o.Shipped == false)
                        .OrderByDescending(o => o.OrderDate)
                        .ThenByDescending(o => o.RequiredDate)
                        .Take(100)
                        .ToListAsync();

        }
    }
}
