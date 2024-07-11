using System.ComponentModel.DataAnnotations;
namespace MoviesPrimeApi.Models
{
    public class Movie
    {
        // Unique identifier for the movie
        public int Id { get; set; }

        // Name of the movie is required and has a default value of an empty string
        [Required]
        public string Name { get; set; } = string.Empty;

        // Description of the movie is required and has a default value of an empty string
        [Required]
        public string Description { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public List<Actor>? Cast { get; set; }


    }
}