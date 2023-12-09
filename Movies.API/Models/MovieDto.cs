using Movies.API.Common;
using System.ComponentModel.DataAnnotations;

namespace Movies.API.Models
{
    public class MovieDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Director { get; set; } = string.Empty;
        public Rating Rating { get; set; }
        public int Duration { get; set; }
        public ICollection<Genre> Genre { get; set; } = new List<Genre>();
        public ICollection<ActorDto> Cast { get; set; } = new List<ActorDto>();
        public int ReleaseYear { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
