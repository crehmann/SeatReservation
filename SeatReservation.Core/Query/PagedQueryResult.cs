using System;
using System.Collections;
using System.Collections.Generic;

namespace SeatReservation.Core.Query
{
    public class PagedQueryResult<T> : IPagedQueryResult<T>
    {
        private readonly List<T> _subset = new List<T>();

        public PagedQueryResult(IEnumerable<T> subset, int pageNumber, int pageSize, int totalItemCount)
        {
            if (pageNumber < 1) throw new ArgumentOutOfRangeException(nameof(pageNumber), "PageNumber cannot be below 1.");
            if (pageSize < 1) throw new ArgumentOutOfRangeException(nameof(pageSize), "PageSize cannot be less than 1.");

            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItemCount = totalItemCount;
            PageCount = TotalItemCount > 0
                        ? (int)Math.Ceiling(TotalItemCount / (double)PageSize)
                        : 0;

            _subset.AddRange(subset);
        }

        /// <summary>
        ///     Gets the number of elements contained on this page.
        /// </summary>
        public int Count
        {
            get { return _subset.Count; }
        }

        /// <summary>
        ///     Total number of subsets within the superset.
        /// </summary>
        /// <value>
        ///     Total number of subsets within the superset.
        /// </value>
        public int PageCount { get; protected set; }

        /// <summary>
        ///     One-based index of this subset within the superset.
        /// </summary>
        /// <value>
        ///     One-based index of this subset within the superset.
        /// </value>
        public int PageNumber { get; protected set; }

        /// <summary>
        ///     Maximum size any individual subset.
        /// </summary>
        /// <value>
        ///     Maximum size any individual subset.
        /// </value>
        public int PageSize { get; protected set; }

        /// <summary>
        ///     Total number of objects contained within the superset.
        /// </summary>
        /// <value>
        ///     Total number of objects contained within the superset.
        /// </value>
        public int TotalItemCount { get; protected set; }

        /// <summary>
        ///     Gets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get.</param>
        public T this[int index]
        {
            get { return _subset[index]; }
        }

        /// <summary>
        ///     Returns an enumerator that iterates through the BasePagedList&lt;T&gt;.
        /// </summary>
        /// <returns>A BasePagedList&lt;T&gt;.Enumerator for the BasePagedList&lt;T&gt;.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _subset.GetEnumerator();
        }

        /// <summary>
        ///     Returns an enumerator that iterates through the BasePagedList&lt;T&gt;.
        /// </summary>
        /// <returns>A BasePagedList&lt;T&gt;.Enumerator for the BasePagedList&lt;T&gt;.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}