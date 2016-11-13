using System;

namespace SeatReservation.Api.Events.ReadModel
{
    public class UpcommingEvent
    {
        public UpcommingEvent(Guid id, string name, DateTime start, DateTime end)
        {
            Id = id;
            Name = name;
            Start = start;
            End = end;
        }

        public DateTime End { get; }
        public Guid Id { get; }
        public string Name { get; }
        public DateTime Start { get; }
    }
}