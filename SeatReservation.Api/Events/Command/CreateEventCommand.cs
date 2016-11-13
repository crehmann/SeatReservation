using SeatReservation.Core.Command;
using System;

namespace SeatReservation.Api.Events.Command
{
    public class CreateEventCommand : ICommand
    {
        public CreateEventCommand(Guid eventId, string name, DateTime start, DateTime end)
        {
            EventId = eventId;
            Name = name;
            Start = start;
            End = end;
        }

        public DateTime End { get; }
        public Guid EventId { get; }
        public string Name { get; }
        public DateTime Start { get; }
    }
}