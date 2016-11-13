using SeatReservation.Api.DataAccess;
using SeatReservation.Api.Events.ReadModel;
using SeatReservation.Core;
using SeatReservation.Core.Query;
using System.Linq;

namespace SeatReservation.Api.Events.Query
{
    public class UpcommingEventsQueryHandler : IQueryHandler<UpcommingEventsQuery, UpcommingEventsQueryResult>
    {
        private readonly ISeatReservationQueryContext _context;

        public UpcommingEventsQueryHandler(ISeatReservationQueryContext context)
        {
            _context = context;
        }

        public Result<UpcommingEventsQueryResult> Retrieve(UpcommingEventsQuery query)
        {
            var events = _context.Events.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize);
            return Result.Ok(new UpcommingEventsQueryResult(events.Select(x => new UpcommingEvent(x.Id, x.Name, x.Start, x.End)), query.PageNumber, query.PageSize, _context.Events.Count()));
        }
    }
}