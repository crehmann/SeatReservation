using SeatReservation.Api.Events.ReadModel;
using SeatReservation.Core.Query;
using System.Collections.Generic;

namespace SeatReservation.Api.Events.Query
{
    public class UpcommingEventsQueryResult : PagedQueryResult<UpcommingEvent>
    {
        public UpcommingEventsQueryResult(IEnumerable<UpcommingEvent> subset, int pageNumber, int pageSize, int totalItemCount) : base(subset, pageNumber, pageSize, totalItemCount)
        {
        }
    }
}