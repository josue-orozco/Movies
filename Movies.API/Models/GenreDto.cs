using Movies.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Movies.API.Models
{
    public class GenreDto
    {
        [Required]
        public Common.Genre MovieGenre { get; set; }
    }
}
