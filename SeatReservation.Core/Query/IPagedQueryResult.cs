using System.Collections.Generic;

namespace SeatReservation.Core.Query
{
    public interface IPagedQueryResult : IQueryResult
    {
        /// <summary>
        ///     Total number of subsets within the superset.
        /// </summary>
        /// <value>
        ///     Total number of subsets within the superset.
        /// </value>
        int PageCount { get; }

        /// <summary>
        ///     One-based index of this subset within the superset.
        /// </summary>
        /// <value>
        ///     One-based index of this subset within the superset.
        /// </value>
        int PageNumber { get; }

        /// <summary>
        ///     Maximum size any individual subset.
        /// </summary>
        /// <value>
        ///     Maximum size any individual subset.
        /// </value>
        int PageSize { get; }

        /// <summary>
        ///     Total number of objects contained within the superset.
        /// </summary>
        /// <value>
        ///     Total number of objects contained within the superset.
        /// </value>
        int TotalItemCount { get; }
    }

    public interface IPagedQueryResult<out T> : IPagedQueryResult, IEnumerable<T>
    {
        /// <summary>
        ///     Gets the number of elements contained on this page.
        /// </summary>
        int Count { get; }

        /// <summary>
        ///     Gets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get.</param>
        T this[int index] { get; }
    }
}