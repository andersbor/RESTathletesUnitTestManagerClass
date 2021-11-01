using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using athleteLibrary;
using athletesREST.Managers;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace athletesREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthletesController : ControllerBase
    {
        private readonly AthletesManager _manager = new AthletesManager();

        // GET: api/<AthletesController>
        [HttpGet]
        public IEnumerable<Athlete> Get([FromQuery] string country=null, [FromQuery] string sortBy=null)
        {
            return _manager.GetAll(country, sortBy);
        }

        // GET api/<AthletesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AthletesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Athlete> Post([FromBody] Athlete value)
        {
            Athlete athlete = _manager.Add(value);
            string uri = Url.RouteUrl(RouteData.Values) + "/" + athlete.Id;
            return Created(uri, athlete);
        }

        // PUT api/<AthletesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AthletesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult< Athlete> Delete(int id)
        {
            Athlete removed = _manager.Delete(id);
            if (removed == null) return NotFound(id);
            return Ok(removed);
        }
    }
}
