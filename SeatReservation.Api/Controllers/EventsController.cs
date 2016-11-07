using Microsoft.AspNetCore.Mvc;
using SeatReservation.Api.Commands;
using SeatReservation.Api.Queries;
using SeatReservation.Api.ViewModels;
using SeatReservation.Common.Cqrs;
using System;

namespace SeatReservation.Api.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public EventsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            if (commandDispatcher == null) throw new ArgumentNullException(nameof(commandDispatcher));
            if (queryDispatcher == null) throw new ArgumentNullException(nameof(queryDispatcher));
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        // DELETE api/events/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET: api/events
        [HttpGet]
        public IActionResult Get()
        {
            return Get(1, 20);
        }

        // GET api/events/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/events
        [HttpPost]
        public IActionResult Post([FromBody]CreateEventViewModel viewModel)
        {
            var id = Guid.NewGuid();
            var result = _commandDispatcher.Dispatch(new CreateEventCommand(id, viewModel.Name, viewModel.Start, viewModel.End));
            if (result.IsSuccess) return Ok(id);
            return Error(result.Error);
        }

        // PUT api/events/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        //[HttpGet]
        private IActionResult Get([FromQuery]int pageNumber, [FromQuery] int pageSize)
        {
            var result = _queryDispatcher.Dispatch<UpcommingEventsQuery, UpcommingEventsQueryResult>(new UpcommingEventsQuery(pageNumber, pageSize));
            if (result.IsSuccess) return Ok(result.Value);
            return Error(result.Error);
        }
    }
}