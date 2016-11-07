using LanguageExt;
using SeatReservation.Common;
using System;

namespace SeatReservation.Domain
{
    public class SeatingPlanCell : Entity
    {
        protected SeatingPlanCell(Guid id, SeatingPlanCellType cellType, Option<Reservation> reservation)
        {
            Id = id;
            CellType = cellType;
            Reservation = reservation;
        }

        private SeatingPlanCell()
        {
        }

        public SeatingPlanCellType CellType { get; private set; }

        public bool IsAssigned => Reservation.IsSome && CellType == SeatingPlanCellType.Assignable;

        public Option<Reservation> Reservation { get; private set; }

        public Result Assign(Reservation reservation)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));
            if (CellType != SeatingPlanCellType.Assignable) return Result.Fail("Cell is not assignable");
            if (Reservation.IsSome) return Result.Fail("Cell is already assigned");
            Reservation = reservation;
            return Result.Ok();
        }

        public Result UpdateCellType(SeatingPlanCellType cellType)
        {
            if (Reservation.IsSome) return Result.Fail("Can not change cell type if it is assigned.");
            CellType = cellType;
            return Result.Ok();
        }

        protected override int GetHashCodeCore()
        {
            return (nameof(SeatingPlanCell) + Id).GetHashCode();
        }
    }
}