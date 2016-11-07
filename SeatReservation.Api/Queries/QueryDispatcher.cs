using SeatReservation.Common;
using SeatReservation.Common.Cqrs;
using System;

namespace SeatReservation.Api.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null) throw new ArgumentNullException(nameof(serviceProvider));
            _serviceProvider = serviceProvider;
        }

        public Result<TResult> Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult
        {
            var handler = (IQueryHandler<TParameter, TResult>)_serviceProvider.GetService(typeof(IQueryHandler<TParameter, TResult>));
            return handler.Retrieve(query);
        }
    }
}