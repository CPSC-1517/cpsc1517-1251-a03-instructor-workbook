using Microsoft.EntityFrameworkCore;

namespace WestWindSystem.DAL
{
    public interface IWestWindDbContextFactory
    {
        Task<DbContext> CreateDbContextAsync(CancellationToken ct = default);
    }
}
