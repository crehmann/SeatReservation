using SeatReservation.Common.Cqrs;
using System;

namespace SeatReservation.Api.Commands
{
    public class CreateEventCommand : ICommand
    {
        public CreateEventCommand(Guid id, string name, DateTime start, DateTime end)
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