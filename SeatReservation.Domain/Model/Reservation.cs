using SeatReservation.Core;
using System;

namespace SeatReservation.Domain.Model
{
    public class Reservation : Entity
    {
        protected Reservation(Guid id, Customer customer, Event @event)
        {
            Id = id;
            Customer = customer;
            Event = @event;
        }

        private Reservation()
        {
        }

        public Customer Customer { get; private set; }
        public Event Event { get; private set; }

        public static Result<Reservation> Create(Guid id, Customer customer, Event @event)
        {
            if (id == Guid.Empty) return Result.Fail<Reservation>("Id must not be empty guid");
            if (customer == null) return Result.Fail<Reservation>("Customer must not be null.");
            if (@event == null) return Result.Fail<Reservation>("Event must not be null.");

            return Result.Ok<Reservation>(new Reservation(id, customer, @event));
        }

        protected override int GetHashCodeCore()
        {
            return (nameof(Reservation) + Id).GetHashCode();
        }
    }
}