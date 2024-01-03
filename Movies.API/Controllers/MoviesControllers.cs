using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Entities;
using Movies.API.Models;
using Movies.API.Services;

namespace Movies.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/movies")]
    [Route("api/v{version:ApiVersion}/movies")]
    public class MoviesControllers : ControllerBase
    {
        private readonly IMoviesRepository moviesRepository;
        private readonly IMapper mapper;
        private readonly ILogger<MoviesControllers> logger;

        public MoviesControllers(IMoviesRepository moviesRepository, IMapper mapper, ILogger<MoviesControllers> logger)
        {
            this.moviesRepository = moviesRepository ?? throw new ArgumentNullException(nameof(moviesRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            var movies = await moviesRepository.GetMoviesAsync();

            return Ok(mapper.Map<IEnumerable<MovieDto>>(movies));
        }

        [HttpGet("{movieTitle}")]
        public async Task<ActionResult<MovieDto>> GetMovie(string movieTitle)
        {
            var movie = await moviesRepository.GetMovieAsync(movieTitle);

            if (movie == null)
            {
                logger.LogInformation($"Movie with title {movieTitle} wasn't found when accessing movies controller.");
                return NotFound();
            }

            return Ok(mapper.Map<MovieDto>(movie));
        }

        [HttpPost]
        public async Task<ActionResult> AddMovie([FromBody] MovieDto movie)
        {
            if (movie == null)
            {
                logger.LogInformation($"No movie data provided in request to be added in movies controller.");
                return BadRequest();
            }
            
            if (await moviesRepository.MovieExistsAsync(movie.Title))
            {
                // Movie entry already exist.
                logger.LogInformation($"Movie with title {movie.Title} already existed in movie controller.");
                return BadRequest();
            }

            var newMovie = mapper.Map<Movie>(movie);

            moviesRepository.AddMovieAsync(newMovie);

            await moviesRepository.SaveChangesAsync();

            var actionName = nameof(MoviesControllers.GetMovie);
            var createdMovie = mapper.Map<MovieDto>(newMovie);
            var routeValues = new { movieTitle = createdMovie.Title};

            return CreatedAtAction(actionName, routeValues, createdMovie);
        }

        [HttpDelete("{movieTitle}")]
        public async Task<ActionResult> RemoveMovie(string movieTitle)
        {
            if (movieTitle == null)
            {
                logger.LogInformation($"No movie title provided in request to be added in movies controller.");
                return BadRequest();
            }

            if (await moviesRepository.MovieExistsAsync(movieTitle) == false)
            {
                logger.LogInformation($"No movie with title {movieTitle} existed in movie controller.");
                return NotFound();
            }

            var movie = await moviesRepository.GetMovieAsync(movieTitle);

            moviesRepository.DeleteMovie(movie);

            await moviesRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
