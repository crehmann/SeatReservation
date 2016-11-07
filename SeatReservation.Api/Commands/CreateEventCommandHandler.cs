using SeatReservation.Api.DataAccess;
using SeatReservation.Api.Model;
using SeatReservation.Common;
using SeatReservation.Common.Cqrs;

namespace SeatReservation.Api.Commands
{
    public class CreateEventCommandHandler : ICommandHandler<CreateEventCommand>
    {
        private SeatReservationContext _context;

        public CreateEventCommandHandler(SeatReservationContext context)
        {
            _context = context;
        }

        public Result Execute(CreateEventCommand command)
        {
            return Event.Create(command.Name, command.Start, command.End).OnSuccess(e => _context.Add(e));
        }
    }
}