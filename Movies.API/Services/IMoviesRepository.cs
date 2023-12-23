using Movies.API.Entities;
using Movies.API.Models;

namespace Movies.API.Services
{
    public interface IMoviesRepository
    {
        Task<bool> MovieExistsAsync(string movieTitle);
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie?> GetMovieAsync(string movieTitle);
        void AddMovieAsync(Movie movie);
        void DeleteMovie(Movie movie);
        Task<bool> SaveChangesAsync();
    }
}
