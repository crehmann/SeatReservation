using Microsoft.AspNetCore.Mvc;
using SeatReservation.Api.Model;

namespace SeatReservation.Api.Controllers
{
    [Route("api/[controller]")]
    public class ControllerBase : Controller
    {
        protected ActionResult Error(string errorMessage)
        {
            return BadRequest(Envelope.Error(errorMessage));
        }

        protected new ActionResult Ok()
        {
            return base.Ok(Envelope.Ok());
        }

        protected new ActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }
    }
}