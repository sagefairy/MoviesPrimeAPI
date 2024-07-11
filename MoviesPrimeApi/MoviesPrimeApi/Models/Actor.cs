using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoviesPrimeApi.Models
{
    public class Actor
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int MovieId { get; set; }

        [JsonIgnore]
        public virtual Movie? Movie { get; set; }

    }

}
