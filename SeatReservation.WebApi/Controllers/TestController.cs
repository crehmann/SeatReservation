using Microsoft.AspNetCore.Mvc;

namespace SeatReservation.Api.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        // POST api/values
        [HttpPost]
        public string Post([FromBody]string value)
        {
            return value;
        }
    }
}