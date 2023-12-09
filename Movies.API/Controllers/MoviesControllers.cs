using Microsoft.AspNetCore.Mvc;
using Movies.API.Models;
using Movies.API.Services;

namespace Movies.API.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesControllers : ControllerBase
    {
        private readonly IMoviesRepository moviesRepository;

        public MoviesControllers(IMoviesRepository moviesRepository)
        {
            this.moviesRepository = moviesRepository ?? throw new ArgumentNullException(nameof(moviesRepository));
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> GetMovies()
        {
            return Ok(moviesRepository.GetMoviesAsync());
        }

        [HttpGet("{movieTitle}", Name = "GetMovie")]
        public ActionResult<MovieDto> GetMovie(string movieTitle)
        {
            var movie = moviesRepository.GetMovieAsync(movieTitle);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        public ActionResult AddMovie([FromBody] MovieDto movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }
            
            if (moviesRepository.MovieExistsAsync(movie.Title) == true)
            {
                // Movie entry already exist.
                // Log
                return BadRequest();
            }

            moviesRepository.AddMovieAsync(movie);

            moviesRepository.SaveChangesAsync();

            return CreatedAtRoute("GetMovie",
                new
                {
                    movieTitle = movie.Title
                },
                movie);
        }

        [HttpDelete("{movieTitle}")]
        public ActionResult RemoveMovie(string movieTitle)
        {
            if (movieTitle == null)
            {
                return BadRequest();
            }

            if (moviesRepository.MovieExistsAsync(movieTitle) == false)
            {
                return NotFound();
            }

            moviesRepository.DeleteMovie(movieTitle);

            moviesRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
