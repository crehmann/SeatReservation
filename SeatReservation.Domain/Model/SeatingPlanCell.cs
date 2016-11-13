using LanguageExt;
using SeatReservation.Core;
using System;

namespace SeatReservation.Domain.Model
{
    public class SeatingPlanCell : SeatingPlanCellTemplate
    {
        protected SeatingPlanCell(Guid id, SeatingPlanCellType cellType, Option<Reservation> reservation) : base(id, cellType)
        {
            Reservation = reservation;
        }

        protected SeatingPlanCell()
        {
        }

        public bool IsAssigned => CellType == SeatingPlanCellType.Assignable && Reservation.IsSome;

        public Option<Reservation> Reservation { get; private set; }

        public static new SeatingPlanCell Create()
        {
            return new SeatingPlanCell(Guid.NewGuid(), SeatingPlanCellType.Unspecified, Option<Reservation>.None);
        }

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