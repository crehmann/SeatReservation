using Microsoft.EntityFrameworkCore;
using SeatReservation.Api.Model;

namespace SeatReservation.Api.DataAccess
{
    public interface ISeatReservationContext
    {
        DbSet<Event> Events { get; }

        void SaveChanges();
    }
}