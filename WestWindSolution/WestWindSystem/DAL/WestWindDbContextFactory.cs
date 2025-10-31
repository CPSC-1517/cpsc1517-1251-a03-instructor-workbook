using Microsoft.EntityFrameworkCore;

namespace WestWindSystem.DAL
{
    internal sealed class WestWindDbContextFactory : IWestWindDbContextFactory
    {
        private readonly IDbContextFactory<WestWindContext> _inner;

        public WestWindDbContextFactory(IDbContextFactory<WestWindContext> inner)
            => _inner = inner;

        public async Task<DbContext> CreateDbContextAsync(CancellationToken ct = default)
        {
            // Await to get WestWindContext, then up-cast to DbContext
            WestWindContext ctx = await _inner.CreateDbContextAsync(ct).ConfigureAwait(false);
            return ctx; // implicit up-cast to DbContext
        }
    }
}
