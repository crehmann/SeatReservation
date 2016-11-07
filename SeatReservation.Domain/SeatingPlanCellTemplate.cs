using SeatReservation.Common;
using System;

namespace SeatReservation.Domain
{
    public class SeatingPlanCellTemplate : Entity
    {
        protected SeatingPlanCellTemplate(Guid id, SeatingPlanCellType cellType)
        {
            Id = id;
            CellType = cellType;
        }

        private SeatingPlanCellTemplate()
        {
        }

        public SeatingPlanCellType CellType { get; private set; }

        protected override int GetHashCodeCore()
        {
            return (nameof(SeatingPlanCellTemplate) + Id).GetHashCode();
        }
    }
}