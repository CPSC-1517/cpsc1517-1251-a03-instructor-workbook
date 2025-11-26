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
                throw new ArgumentOutOfRangeException(nameof(month), $"Invalid month {month}. Month must be between 1 and 12.");
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

        public async Task<int> CountShipmentsByYearAndMonth(int year, int month)
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

        public async Task<Shipment> AddShipmentAsync(Shipment newShipment)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();

            context.Shipments.Add(newShipment);
            await context.SaveChangesAsync();

            // After SaveChanges, EF Core will set the new ShipmentID
            return newShipment;

        }

        public async Task<Shipment?> FindShipmentByShipmentId(int shipmentId)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            //return await context.Shipments
            //    .Where(s => s.ShipmentID == shipmentId)
            //    .FirstOrDefaultAsync();
            return await context.Shipments
                .FirstOrDefaultAsync(s => s.ShipmentID == shipmentId);
        }

        public async Task UpdateShipmentAsync(Shipment updatedShipment)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();

            context.Shipments.Update(updatedShipment);
            await context.SaveChangesAsync();
        }

        public async Task DeleteShipmentAsync(int shipmentId)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();

            var existing = await context.Shipments.FindAsync(shipmentId);
            if (existing == null)
            {
                throw new ArgumentException($"Shipment {shipmentId} does not exist.");
            }

            context.Shipments.Remove(existing);
            await context.SaveChangesAsync();
        }

    }

}