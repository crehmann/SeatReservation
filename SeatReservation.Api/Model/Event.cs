using LanguageExt;
using SeatReservation.Common;
using System;

namespace SeatReservation.Api.Model
{
    public class Event : Entity
    {
        protected Event(string name, DateTime start, DateTime end)
        {
            Name = name;
            Start = start;
            End = end;
        }

        private Event()
        {
        }

        public DateTime End { get; private set; }
        public string Name { get; private set; }
        public DateTime Start { get; private set; }

        public static Result<Event> Create(string name, DateTime start, DateTime end)
        {
            return Create(Guid.NewGuid(), name, start, end);
        }

        public static Result<Event> Create(Guid id, string name, DateTime start, DateTime end)
        {
            if (id == Guid.Empty) return Result.Fail<Event>("Id must not be empty guid");
            if (string.IsNullOrWhiteSpace(name)) return Result.Fail<Event>("Name must not be empty");
            if (DateTime.UtcNow > start) return Result.Fail<Event>("Start date must not be in the past");
            if (end < start) return Result.Fail<Event>("Start date must be before end date");
            return Result.Ok<Event>(new Event(name, start, end));
        }

        protected override int GetHashCodeCore()
        {
            return (typeof(Event).FullName + Id).GetHashCode();
        }
    }
}