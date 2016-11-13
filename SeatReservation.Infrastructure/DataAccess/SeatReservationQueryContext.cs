using SeatReservation.Api.DataAccess;
using SeatReservation.Domain.Model;
using System;
using System.Linq;

namespace SeatReservation.Infrastructure.DataAccess
{
    public class SeatReservationQueryContext : ISeatReservationQueryContext, IDisposable
    {
        private readonly ISeatReservationQueryContext _dbContext;

        public SeatReservationQueryContext(ISeatReservationQueryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Event> Events => _dbContext.Events;

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}