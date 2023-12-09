using Movies.API.Models;

namespace Movies.API.Services
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MoviesDataStore moviesDataStore;

        public MoviesRepository(MoviesDataStore moviesDataStore)
        {
            this.moviesDataStore = moviesDataStore ?? throw new ArgumentNullException(nameof(moviesDataStore));
        }

        public void AddMovieAsync(MovieDto movie)
        {
            moviesDataStore.Movies.Add(movie);
        }

        public void DeleteMovie(string movieName)
        {
            if (MovieExistsAsync(movieName))
            {
                moviesDataStore.Movies.RemoveAll(m => m.Title == movieName);
            }
        }

        public MovieDto? GetMovieAsync(string movieName)
        {
            return moviesDataStore.Movies.FirstOrDefault(m => m.Title == movieName);
        }

        public IEnumerable<MovieDto> GetMoviesAsync()
        {
            return moviesDataStore.Movies.OrderBy(m => m.Title).ToList();
        }

        public bool MovieExistsAsync(string movieTitle)
        {
            return moviesDataStore.Movies.Any(m => m.Title == movieTitle);
        }

        public bool SaveChangesAsync()
        {
            //do nothing until we have a DB
            return true;
        }
    }
}
