using LanguageExt;
using SeatReservation.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeatReservation.Domain.Model
{
    public class SeatingPlan : SeatingPlanBase<SeatingPlanCell>
    {
        protected SeatingPlan(Guid id, int columns, int rows, IList<SeatingPlanCell> cells) : base(id, columns, rows, cells)
        {
        }

        protected SeatingPlan()
        {
        }

        public static Result<SeatingPlan> Create(Guid id, Event e, int columns, int rows)
        {
            if (id == Guid.Empty) return Result.Fail<SeatingPlan>("Id must not be empty guid");
            if (e == null) return Result.Fail<SeatingPlan>("Event must not be null");
            if (rows <= 0) return Result.Fail<SeatingPlan>("Rows must be greater than zero");
            if (columns <= 0) return Result.Fail<SeatingPlan>("Columns must be greater than zero");

            var cells = CreateCells(columns * rows);
            return Result.Ok(new SeatingPlan(id, columns, rows, cells));
        }

        protected override int GetHashCodeCore()
        {
            return (nameof(SeatingPlan) + Id).GetHashCode();
        }

        private static IList<SeatingPlanCell> CreateCells(int count)
        {
            var cells = new List<SeatingPlanCell>();
            for (var i = 0; i < count; i++)
            {
                cells.Add(SeatingPlanCell.Create());
            }

            return cells;
        }
    }
}