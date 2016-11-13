using System.Linq;

namespace SeatReservation.Api.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Delete(object id);

        IQueryable<TEntity> Get();

        void Update(TEntity entityToUpdate);
    }
}