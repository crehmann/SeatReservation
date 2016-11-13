namespace SeatReservation.Api.DataAccess
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}