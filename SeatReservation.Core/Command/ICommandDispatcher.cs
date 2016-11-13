namespace SeatReservation.Core.Command
{
    public interface ICommandDispatcher
    {
        Result Dispatch<TParameter>(TParameter command) where TParameter : ICommand;
    }
}