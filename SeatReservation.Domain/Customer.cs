using LanguageExt;
using SeatReservation.Common;
using System;

namespace SeatReservation.Domain
{
    public class Customer : Entity
    {
        protected Customer(Guid id, string firstName, string lastName, Option<string> address, Option<string> city, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            Phone = phone;
        }

        private Customer()
        {
        }

        public Option<string> Address { get; private set; }

        public Option<string> City { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Phone { get; private set; }

        public static Result<Customer> Create(Guid id, string firstName, string lastName, Option<string> address, Option<string> city, string phone)
        {
            if (id == Guid.Empty) return Result.Fail<Customer>("Id must not be empty guid");
            if (string.IsNullOrWhiteSpace(firstName)) return Result.Fail<Customer>("FirstName must not be empty");
            if (string.IsNullOrWhiteSpace(lastName)) return Result.Fail<Customer>("LastName must not be empty");
            if (string.IsNullOrWhiteSpace(phone)) return Result.Fail<Customer>("Phone must not be empty");
            return Result.Ok<Customer>(new Customer(id, firstName, lastName, address, city, phone));
        }

        public static Result<Customer> Create(string firstName, string lastName, Option<string> address, Option<string> city, string phone)
        {
            return Create(Guid.NewGuid(), firstName, lastName, address, city, phone);
        }

        protected override int GetHashCodeCore()
        {
            return (nameof(Customer) + Id).GetHashCode();
        }
    }
}