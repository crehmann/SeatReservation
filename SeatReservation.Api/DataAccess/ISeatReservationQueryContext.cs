using SeatReservation.Domain.Model;
using System;
using System.Linq;

namespace SeatReservation.Api.DataAccess
{
    public interface ISeatReservationQueryContext : IDisposable
    {
        IQueryable<Event> Events { get; }
    }
}