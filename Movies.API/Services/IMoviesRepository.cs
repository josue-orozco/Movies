using Movies.API.Models;

namespace Movies.API.Services
{
    public interface IMoviesRepository
    {
        IEnumerable<MovieDto> GetMoviesAsync();
        MovieDto? GetMovieAsync(string movieName);
        void AddMovieAsync(MovieDto movie);
        void DeleteMovie(string movieName);
        bool SaveChangesAsync();

        bool MovieExistsAsync(string movieTitle);
    }
}
