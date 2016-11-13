using SeatReservation.Api.DataAccess;
using SeatReservation.Core;
using SeatReservation.Core.Command;
using System;

namespace SeatReservation.Api
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUnitOfWork _unitOfWork;

        public CommandDispatcher(IServiceProvider seviceProvider, IUnitOfWork unitOfWork)
        {
            if (seviceProvider == null) throw new ArgumentNullException(nameof(seviceProvider));
            if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));
            _serviceProvider = seviceProvider;
            _unitOfWork = unitOfWork;
        }

        public Result Dispatch<TParameter>(TParameter command) where TParameter : ICommand
        {
            var handler = (ICommandHandler<TParameter>)_serviceProvider.GetService(typeof(ICommandHandler<TParameter>));
            return handler.Execute(command)
                .OnSuccess(() => _unitOfWork.SaveChanges());
        }
    }
}