using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using TripsApi.Models;

namespace TripsApi.Controllers
{
    [Route("api/Trips")]
    [ApiController]

    /* If the [HttpGet] attribute has a route template (for example, [HttpGet("products")]), append that to the path. 
     * This sample doesn't use a template. 
     * For more information, see Attribute routing with Http[Verb] attributes.
     * https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-5.0#verb
     */

    public class TripsController : ControllerBase
    {
        private readonly TripsContext _context;

        public TripsController(TripsContext context)
        {
            _context = context;
        }

        // GET: api/Trips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trip>>> GetTrips()
        {
            return await _context.Trips.ToListAsync();
        }

        // GET: api/Trips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> GetTrip(long id)
        {
            var trip = await _context.Trips.FindAsync(id);

            if (trip == null)
            {
                return NotFound();
            }

            return trip;
        }

        // PUT: api/Trips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrip(long id, Trip trip)
        {
            if (id != trip.Id)
            {
                return BadRequest();
            }

            _context.Entry(trip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Trips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trip>> PostTrip(Trip trip)
        {
            BusinessLogic.createTrip(trip);

            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTrip", new { id = trip.TripId }, trip);
            return CreatedAtAction(nameof(GetTrip), new { id = trip.Id }, trip);
        }

        // DELETE: api/Trips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(long id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }

            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TripExists(long id)
        {
            return _context.Trips.Any(e => e.Id == id);
        }
    }
}
