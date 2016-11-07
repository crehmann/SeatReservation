using SeatReservation.Api.DataAccess;
using SeatReservation.Common;
using SeatReservation.Common.Cqrs;
using System;

namespace SeatReservation.Api.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly SeatReservationContext _context;
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider seviceProvider, SeatReservationContext context)
        {
            if (seviceProvider == null) throw new ArgumentNullException(nameof(seviceProvider));
            if (context == null) throw new ArgumentNullException(nameof(context));
            _serviceProvider = seviceProvider;
            _context = context;
        }

        public Result Dispatch<TParameter>(TParameter command) where TParameter : ICommand
        {
            var handler = (ICommandHandler<TParameter>)_serviceProvider.GetService(typeof(ICommandHandler<TParameter>));
            return handler.Execute(command).OnSuccess(() => _context.SaveChanges());
        }
    }
}