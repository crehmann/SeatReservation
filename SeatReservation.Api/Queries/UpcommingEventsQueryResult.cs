using SeatReservation.Api.Model;
using SeatReservation.Common.Cqrs;
using System.Collections.Generic;

namespace SeatReservation.Api.Queries
{
    public class UpcommingEventsQueryResult : PagedQueryResult<Event>
    {
        public UpcommingEventsQueryResult(IEnumerable<Event> subset, int pageNumber, int pageSize, int totalItemCount) : base(subset, pageNumber, pageSize, totalItemCount)
        {
        }
    }
}