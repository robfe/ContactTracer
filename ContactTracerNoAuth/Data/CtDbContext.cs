using Microsoft.EntityFrameworkCore;

namespace ContactTracerNoAuth.Data
{
    public class CtDbContext:DbContext
    {
        public CtDbContext(DbContextOptions<CtDbContext> options)
            : base(options)
        {
        }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Checkin> Checkins { get; set; }
    }
}