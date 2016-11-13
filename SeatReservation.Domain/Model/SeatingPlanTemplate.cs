using SeatReservation.Core;
using System;
using System.Collections.Generic;

namespace SeatReservation.Domain.Model
{
    public class SeatingPlanTemplate : SeatingPlanBase<SeatingPlanCellTemplate>
    {
        protected SeatingPlanTemplate(Guid id, string name, int columns, int rows, IList<SeatingPlanCellTemplate> cells) : base(id, columns, rows, cells)
        {
            Name = name;
        }

        protected SeatingPlanTemplate()
        {
        }

        public string Name { get; private set; }

        public static Result<SeatingPlanTemplate> Create(Guid id, string name, Event e, int columns, int rows)
        {
            if (id == Guid.Empty) return Result.Fail<SeatingPlanTemplate>("Id must not be empty guid");
            if (string.IsNullOrEmpty(name)) return Result.Fail<SeatingPlanTemplate>("Name must not be null or empty");
            if (e == null) return Result.Fail<SeatingPlanTemplate>("Event must not be null");
            if (rows <= 0) return Result.Fail<SeatingPlanTemplate>("Rows must be greater than zero");
            if (columns <= 0) return Result.Fail<SeatingPlanTemplate>("Columns must be greater than zero");

            var cells = CreateCells(columns * rows);
            return Result.Ok(new SeatingPlanTemplate(id, name, columns, rows, cells));
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }

        private static IList<SeatingPlanCellTemplate> CreateCells(int count)
        {
            var cells = new List<SeatingPlanCellTemplate>();
            for (var i = 0; i < count; i++)
            {
                cells.Add(SeatingPlanCellTemplate.Create());
            }

            return cells;
        }
    }
}