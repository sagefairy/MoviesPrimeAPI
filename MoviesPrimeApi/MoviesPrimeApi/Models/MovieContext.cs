using Microsoft.EntityFrameworkCore;

namespace MoviesPrimeApi.Models
{
        // DbContext for the application, representing a session with the database
        public class MovieContext : DbContext
        {
            // Constructor that accepts DbContextOptions and passes them to the base class constructor
            public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

            // Method to configure the model and its relationships
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Configures the relationship between Movie and Actor
                modelBuilder.Entity<Movie>()
                    .HasMany(movie => movie.Cast) // A Movie has many Cast
                    .WithOne(actor => actor.Movie) // Each Actor is to one Movie
                    .HasForeignKey(a => a.MovieId); // The foreign key is MovieId

                // Seeds initial data into the database (if the Seed method is defined)
                modelBuilder.Seed();
            }

            // DbSet representing the Movies table
            public DbSet<Movie> Movies { get; set; }

            // DbSet representing the Actors table
            public DbSet<Actor> Actors { get; set; }
        }
    }

