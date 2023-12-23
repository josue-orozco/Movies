using Movies.API.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.API.Entities
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Director { get; set; } = string.Empty;
        public Rating Rating { get; set; }
        public int Duration { get; set; }
        public int ReleaseYear { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public ICollection<Actor> Cast { get; set; } = new List<Actor>();

        public Movie(string title)
        {
            Title = title;
        }
    }
}
