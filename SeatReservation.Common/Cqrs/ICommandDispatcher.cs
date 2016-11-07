namespace SeatReservation.Common.Cqrs
{
    public interface ICommandDispatcher
    {
        Result Dispatch<TParameter>(TParameter command) where TParameter : ICommand;
    }
}