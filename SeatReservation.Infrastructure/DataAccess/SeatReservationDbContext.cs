using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SeatReservation.Domain.Model;

namespace SeatReservation.Api.DataAccess
{
    public class SeatReservationDbContext : DbContext
    {
        private IConfigurationRoot _config;

        public SeatReservationDbContext(IConfigurationRoot config, DbContextOptions options)
      : base(options)
        {
            _config = config;
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase();
        }
    }
}