using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;

//using ModelF;

namespace ApiControllers.Controllers
{
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        [HttpGet("ali")]
        public string GetString() => "This is a string response";

        [HttpGet("reza")]
        [Produces("application/xml")]
        public Reservation GetObject() => new Reservation
        {
            ReservationId = 100,
            ClientName = "Joe",
            Location = "Board Room"
        };
    }
}
