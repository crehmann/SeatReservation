using SeatReservation.Api.DataAccess;
using SeatReservation.Common;
using SeatReservation.Common.Cqrs;
using System.Linq;

namespace SeatReservation.Api.Queries
{
    public class UpcommingEventsQueryHandler : IQueryHandler<UpcommingEventsQuery, UpcommingEventsQueryResult>
    {
        private readonly SeatReservationContext _context;

        public UpcommingEventsQueryHandler(SeatReservationContext context)
        {
            _context = context;
        }

        public Result<UpcommingEventsQueryResult> Retrieve(UpcommingEventsQuery query)
        {
            var events = _context.Events.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize);
            return Result.Ok(new UpcommingEventsQueryResult(events, query.PageNumber, query.PageSize, _context.Events.Count()));
        }
    }
}