using Microsoft.EntityFrameworkCore;

namespace NphiesMiddleware.Persistence;

public class MiddlewareDbContext : DbContext
{
    public MiddlewareDbContext(DbContextOptions<MiddlewareDbContext> options) : base(options) { }

    // TODO: Add DbSet properties
}
