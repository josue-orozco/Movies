using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Entities;
using Movies.API.Models;
using Movies.API.Services;

namespace Movies.API.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesControllers : ControllerBase
    {
        private readonly IMoviesRepository moviesRepository;
        private readonly IMapper mapper;

        public MoviesControllers(IMoviesRepository moviesRepository, IMapper mapper)
        {
            this.moviesRepository = moviesRepository ?? throw new ArgumentNullException(nameof(moviesRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            var movies = await moviesRepository.GetMoviesAsync();

            return Ok(mapper.Map<IEnumerable<MovieDto>>(movies));
        }

        [HttpGet("{movieTitle}", Name = "GetMovie")]
        public async Task<ActionResult<MovieDto>> GetMovie(string movieTitle)
        {
            var movie = await moviesRepository.GetMovieAsync(movieTitle);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<MovieDto>(movie));
        }

        [HttpPost]
        public async Task<ActionResult> AddMovie([FromBody] MovieDto movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }
            
            if (await moviesRepository.MovieExistsAsync(movie.Title))
            {
                // Movie entry already exist.
                return BadRequest();
            }

            var newMovie = mapper.Map<Movie>(movie);

            moviesRepository.AddMovieAsync(newMovie);

            await moviesRepository.SaveChangesAsync();

            var createdMovie = mapper.Map<MovieDto>(newMovie);

            return CreatedAtRoute("GetMovie",
                new
                {
                    movieTitle = createdMovie.Title
                },
                createdMovie);
        }

        [HttpDelete("{movieTitle}")]
        public async Task<ActionResult> RemoveMovie(string movieTitle)
        {
            if (movieTitle == null)
            {
                return BadRequest();
            }

            if (await moviesRepository.MovieExistsAsync(movieTitle) == false)
            {
                return NotFound();
            }

            var movie = await moviesRepository.GetMovieAsync(movieTitle);

            moviesRepository.DeleteMovie(movie);

            await moviesRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
