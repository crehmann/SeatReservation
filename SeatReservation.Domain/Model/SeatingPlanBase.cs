using System;
using System.Collections.Generic;
using System.Linq;

namespace SeatReservation.Domain.Model
{
    public abstract class SeatingPlanBase<TCell> : Entity where TCell : SeatingPlanCellTemplate
    {
        protected SeatingPlanBase()
        {
        }

        protected SeatingPlanBase(Guid id, int columns, int rows, IList<TCell> cells)
        {
            if (columns * rows != cells.Count)
            {
                throw new ArgumentException("number of columns and rows does not correspond with number of cells");
            }

            Id = id;
            SeatAssignmentsInteral = cells.ToList();
            Columns = columns;
            Rows = rows;
        }

        public int Columns { get; private set; }

        public int Rows { get; private set; }

        protected virtual IList<TCell> SeatAssignmentsInteral { get; private set; }

        public TCell this[int x, int y]
        {
            get
            {
                if (x >= Columns) throw new IndexOutOfRangeException($"index x is out of range ({x})");
                if (y >= Rows) throw new IndexOutOfRangeException($"index y is out of range ({y})");
                var index = y * Columns + x;
                return SeatAssignmentsInteral[index];
            }
        }
    }
}