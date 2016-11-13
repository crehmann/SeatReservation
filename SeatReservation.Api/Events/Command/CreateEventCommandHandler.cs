using SeatReservation.Api.DataAccess;
using SeatReservation.Core;
using SeatReservation.Core.Command;
using SeatReservation.Domain.Model;
using System;

namespace SeatReservation.Api.Events.Command
{
    public class CreateEventCommandHandler : ICommandHandler<CreateEventCommand>
    {
        private IEventRepository _context;

        public CreateEventCommandHandler(IEventRepository context)
        {
            _context = context;
        }

        public Result Execute(CreateEventCommand command)
        {
            return Event.Create(Guid.NewGuid(), command.Name, command.Start, command.End, null).OnSuccess(e => _context.Add(e));
        }
    }
}