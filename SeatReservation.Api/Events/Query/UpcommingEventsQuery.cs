using SeatReservation.Core.Query;

namespace SeatReservation.Api.Events.Query
{
    public class UpcommingEventsQuery : IQuery
    {
        public UpcommingEventsQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; }

        public int PageSize { get; }
    }
}