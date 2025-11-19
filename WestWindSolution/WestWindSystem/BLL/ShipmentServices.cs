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
    public class ShipmentServices
    {
        private readonly IDbContextFactory<WestWindContext> _dbContextFactory;

        internal ShipmentServices(IDbContextFactory<WestWindContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<List<Shipment>> FindShipmentsByYearAndMonth(int year, int month)
        {
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(month),$"Invalid month {month}. Month must be between 1 and 12.");
            }
            if (year < 1990 || year > DateTime.Today.Year)
            {
                throw new ArgumentOutOfRangeException(nameof(year), $"Invalid year {year}. Year must be between 1990 and {DateTime.Today.Year} ");
            }

            await using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Shipments
                .Include(s => s.ShipViaNavigation)
                .Where(s => s.ShippedDate.Year == year && s.ShippedDate.Month == month)
                .OrderBy(s => s.ShippedDate)
                .ToListAsync();
        }

        public async Task<int> GetShipmentCountByYearAndMonth(int year, int month)
        {
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(month), $"Invalid month {month}. Month must be between 1 and 12.");
            }
            if (year < 1990 || year > DateTime.Today.Year)
            {
                throw new ArgumentOutOfRangeException(nameof(year), $"Invalid year {year}. Year must be between 1990 and {DateTime.Today.Year} ");
            }

            await using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Shipments
                .Where(s => s.ShippedDate.Year == year && s.ShippedDate.Month == month)
                .CountAsync();
        }


        public async Task<List<Shipment>> FindShipmentsByYearAndMonthPaging(
            int year, 
            int month,
            int currentPageNumber, 
            int itemsPerPage)
        {
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(month), $"Invalid month {month}. Month must be between 1 and 12.");
            }
            if (year < 1990 || year > DateTime.Today.Year)
            {
                throw new ArgumentOutOfRangeException(nameof(year), $"Invalid year {year}. Year must be between 1990 and {DateTime.Today.Year} ");
            }

            // Calculate the number of records to skip
            int recordsSkipped = itemsPerPage * (currentPageNumber - 1);

            await using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.Shipments
                .Include(s => s.ShipViaNavigation)
                .Where(s => s.ShippedDate.Year == year && s.ShippedDate.Month == month)
                .OrderBy(s => s.ShippedDate)
                .Skip(recordsSkipped)
                .Take(itemsPerPage)
                .ToListAsync();
        }

    }
}
