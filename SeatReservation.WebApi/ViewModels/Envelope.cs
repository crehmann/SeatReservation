using System;

namespace SeatReservation.Api.ViewModels
{
    public class Envelope<T>
    {
        protected internal Envelope(T result, string errorMessage)
        {
            Result = result;
            ErrorMessage = errorMessage;
            TimeGenerated = DateTime.UtcNow;
        }

        public string ErrorMessage { get; }
        public T Result { get; }
        public DateTime TimeGenerated { get; }
    }

    public class Envelope : Envelope<string>
    {
        protected Envelope(string errorMessage)
            : base(string.Empty, errorMessage)
        {
        }

        public static Envelope Error(string errorMessage)
        {
            return new Envelope(errorMessage);
        }

        public static Envelope<T> Ok<T>(T result)
        {
            return new Envelope<T>(result, string.Empty);
        }

        public static Envelope Ok()
        {
            return new Envelope(string.Empty);
        }
    }
}