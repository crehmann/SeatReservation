using LanguageExt;
using SeatReservation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using static LanguageExt.List;

namespace SeatReservation.Domain
{
    public class SeatingPlan : Entity
    {
        protected SeatingPlan(int columns, int rows, IList<SeatingPlanCell> cells)
        {
            if (columns * rows != cells.Count)
            {
                throw new ArgumentException("number of columns and rows does not correspond with number of cells");
            }

            SeatAssignmentsInteral = cells.ToList();
            Columns = columns;
            Rows = rows;
        }

        private SeatingPlan()
        {
        }

        public int Columns { get; private set; }
        public int Rows { get; set; }
        public IReadOnlyCollection<SeatingPlanCell> SeatAssignments => (IReadOnlyCollection<SeatingPlanCell>)SeatAssignmentsInteral;
        protected virtual ICollection<SeatingPlanCell> SeatAssignmentsInteral { get; private set; }

        public static Result<SeatingPlan> Create(Event e, int columns, int rows)
        {
            if (e == null) return Result.Fail<SeatingPlan>("Event must not be null");
            if (rows < 0) return Result.Fail<SeatingPlan>("Rows must be greater than zero");
            if (columns < 0) return Result.Fail<SeatingPlan>("Columns must be greater than zero");

            return Result.Ok(new SeatingPlan(columns, rows, cells));
        }

        protected override int GetHashCodeCore()
        {
            return (nameof(SeatingPlan) + Id).GetHashCode();
        }

        private Result<IList<SeatingPlanCell>> CreateCollection(int count)
        {
            var cells = new List<SeatingPlanCell>();
            for (var i = 0; i < count; i++)
            {
                cells.Add(SeatingPlanCell.)
            }

            return cells;
        }
    }
}