using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesPrimeApi.Models;

namespace MoviesPrimeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        // The context of the database
        // _context represents a session in the database.
        // You can access and query the tables in the database.
        private readonly MovieContext _context;

        public ActorsController(MovieContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]

        public async Task<ActionResult> Get()
        {
            var actors = await _context.Actors
                .Include(actor => actor.Movie)
                .ToListAsync();

            return Ok(actors);
        }

        [HttpGet("{id}")] // For geting a single actor using the actor's ID
        public async Task<ActionResult> GetActor(int id)
        {
            var actor = await _context.Actors
                .Include(actor => actor.Movie)
                .FirstOrDefaultAsync(actor => actor.Id == id);

            if (actor == null) return NotFound(); // NotFound() is the HTTP Error 404 Response Code meaning the resource could not be found
            return Ok(actor); // Ok() is the HTTP 200 Response code meaning the resource was returned successfully.
        }

        [HttpPost] // For adding a single record to the actor table
        public async Task<ActionResult<Actor>> CreateActor(Actor actor)
        {
            
            var actorr = new Actor()
            {

                Id = actor.Id,
                Name = actor.Name,
                MovieId = actor.MovieId
            };

            // Add the actor to the Actor table and save the context.
            _context.Actors.Add(actorr);
            await _context.SaveChangesAsync();

            // returning a CreatedAtAction will return a HTTP 201 Response code,
            // which means that the resource has been successfully created.
            return CreatedAtAction(
                // API call to make when the resource creation succeeds
                nameof(GetActor),
                // Route of the resource
                new { actor.Id },
                // The resource to return in the POST call.
                await _context.Actors
                    .Include(a => a.Movie)
                    .FirstOrDefaultAsync(a => a.Id == actor.Id)
            );
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Actor>> DeleteActor(int id)
        {
            // Finds the actor by ID
            var actor = await _context.Actors.FindAsync(id);
            if (actor == null)
            {
                // Returns 404 if the actor is not found
                return NotFound();
            }

            // Removes the movie from the context
            _context.Actors.Remove(actor);
            // Saves the changes to the database
            await _context.SaveChangesAsync();

            // Returns the deleted actor
            return actor;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutActor(int id, Actor actor)
        {
            // Checks if the provided ID matches the actors ID
            if (id != actor.Id)
            {
                return BadRequest();
            }

            // Marks the actor entity as modified
            _context.Entry(actor).State = EntityState.Modified;

            try
            {
                // Attempts to save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Checks if the actor still exists in the database
                if (!_context.Movies.Any(p => p.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    // Throws if another exception occurs
                    throw;
                }
            }

            // Returns 204 No Content if successful
            return NoContent();
        }
    }

}
