﻿using Movies.API.Common;
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
        public int ReleaseYear { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<GenreDto> Genres { get; set; } = new List<GenreDto>();
        public ICollection<ActorDto> Cast { get; set; } = new List<ActorDto>();
    }
}
