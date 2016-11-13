using SeatReservation.Core;
using System;

namespace SeatReservation.Domain.Model
{
    public class SeatingPlanCellTemplate : Entity
    {
        protected SeatingPlanCellTemplate(Guid id, SeatingPlanCellType cellType)
        {
            Id = id;
            CellType = cellType;
        }

        protected SeatingPlanCellTemplate()
        {
        }

        public SeatingPlanCellType CellType { get; protected set; }

        public static SeatingPlanCellTemplate Create()
        {
            return new SeatingPlanCellTemplate(Guid.NewGuid(), SeatingPlanCellType.Unspecified);
        }

        protected override int GetHashCodeCore()
        {
            return (nameof(SeatingPlanCellTemplate) + Id).GetHashCode();
        }
    }
}