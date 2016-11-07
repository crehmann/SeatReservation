using System;

namespace SeatReservation.Api.ViewModels
{
    public class CreateEventViewModel
    {
        public DateTime End { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
    }
}