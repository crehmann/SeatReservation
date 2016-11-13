using SeatReservation.Core;
using System;

namespace SeatReservation.Domain.Model
{
    public class Event : Entity
    {
        protected Event(Guid id, string name, DateTime start, DateTime end, SeatingPlan seatingPlan)
        {
            Id = id;
            Name = name;
            Start = start;
            End = end;
            SeatingPlan = seatingPlan;
        }

        private Event()
        {
        }

        public DateTime End { get; private set; }
        public string Name { get; private set; }
        public SeatingPlan SeatingPlan { get; private set; }
        public DateTime Start { get; private set; }

        public static Result<Event> Create(string name, DateTime start, DateTime end, SeatingPlan seatingPlan)
        {
            return Create(Guid.NewGuid(), name, start, end, seatingPlan);
        }

        public static Result<Event> Create(Guid id, string name, DateTime start, DateTime end, SeatingPlan seatingPlan)
        {
            if (id == Guid.Empty) return Result.Fail<Event>("Id must not be empty guid");
            if (string.IsNullOrWhiteSpace(name)) return Result.Fail<Event>("Name must not be empty");
            if (DateTime.UtcNow > start) return Result.Fail<Event>("Start date must not be in the past");
            if (end < start) return Result.Fail<Event>("Start date must be before end date");
            if (seatingPlan == null) Result.Fail<Event>("Seating plan must not be null");
            return Result.Ok<Event>(new Event(id, name, start, end, seatingPlan));
        }

        protected override int GetHashCodeCore()
        {
            return (nameof(Event) + Id).GetHashCode();
        }
    }
}