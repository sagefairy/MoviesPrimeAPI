using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesPrimeApi.Models;

namespace MoviesPrimeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]

        public async Task<ActionResult> Get()
        {
            var movies = await _context.Movies
                .Include(movie => movie.Cast)
                .ToListAsync();
           
            return Ok(movies);
        }


        // POST: api/movies
        [HttpPost]
        public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
        {

            //Validates the model state, uncomment if you have validation rules
            //if (!ModelState.IsValid) {
            //    return BadRequest();
            //}

            var moviess = new Movie()
            {

                Id = movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                Genre = movie.Genre
            };

            
            _context.Movies.Add(moviess);
            await _context.SaveChangesAsync();


            return CreatedAtAction(

                nameof(Get),
                new { movie.Id },

                await _context.Movies
                    .Include(m => m.Cast)
                    .FirstOrDefaultAsync(m => m.Id == movie.Id));
            /*
            // Adds the new movie to the context
            _context.Movies.Add(movie);
            // Saves the changes to the database
            await _context.SaveChangesAsync();

            // Returns a 201 Created response with a link to the newly created movie
            return CreatedAtAction(
                "GetMovie",
                new { id = movie.Id },
                movie);*/
        }

        // PUT: api/movies/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> PutMovie(int id, Movie movie)
        {
            // Checks if the provided ID matches the movie's ID
            if (id != movie.Id)
            {
                return BadRequest();
            }

            // Marks the movie entity as modified
            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                // Attempts to save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Checks if the movie still exists in the database
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
        //Get: api/movies/{id}

        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            movie.Cast = await _context.Actors.Where(actor => movie.Id == actor.MovieId).ToListAsync();
            return Ok(movie);
        }


        // DELETE: api/movies/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            // Finds the movie by ID
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                // Returns 404 if the movie is not found
                return NotFound();
            }

            // Removes the movie from the context
            _context.Movies.Remove(movie);
            // Saves the changes to the database
            await _context.SaveChangesAsync();

            // Returns the deleted movie
            return movie;
        }

        // POST: api/movies/Delete?ids=1&ids=2&ids=3movies
        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult> DeleteMultiple([FromQuery] int[] ids)
        {
            var movies = new List<Movie>();
            foreach (var id in ids)
            {
                var movie = await _context.Movies.FindAsync(id);

                if (movie == null)
                {
                    return NotFound();
                }

                // Adds the movie to the list of movies to be deleted
                movies.Add(movie);
            }

            // Removes all the movies in the list from the context
            _context.Movies.RemoveRange(movies);
            // Saves the changes to the database
            await _context.SaveChangesAsync();

            // Returns the deleted movies
            return Ok(movies);
        }
    }
}

