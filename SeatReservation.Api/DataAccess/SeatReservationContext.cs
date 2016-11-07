using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SeatReservation.Api.Model;

namespace SeatReservation.Api.DataAccess
{
    public class SeatReservationContext : DbContext, ISeatReservationContext
    {
        private IConfigurationRoot _config;

        public SeatReservationContext(IConfigurationRoot config, DbContextOptions options)
      : base(options)
        {
            _config = config;
        }

        public DbSet<Event> Events { get; set; }

        void ISeatReservationContext.SaveChanges()
        {
            base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase();
        }
    }
}