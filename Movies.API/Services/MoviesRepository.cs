using Microsoft.EntityFrameworkCore;
using Movies.API.DbContexts;
using Movies.API.Entities;
using Movies.API.Models;

namespace Movies.API.Services
{
    public class MoviesRepository : IMoviesRepository
    {
        //private readonly MoviesDataStore moviesDataStore;
        private readonly MoviesContext context;

        public MoviesRepository(MoviesContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> MovieExistsAsync(string movieTitle)
        {
            return await context.Movies.AnyAsync(m => m.Title == movieTitle);
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            var temp = await context.Movies.Include(x => x.Genres).Include(x => x.Cast).OrderBy(m => m.Title).ToListAsync();

            return temp;
        }

        public async Task<Movie?> GetMovieAsync(string movieTitle)
        {
            return await context.Movies.Include(x => x.Genres).Include(x => x.Cast).FirstOrDefaultAsync(m => m.Title == movieTitle);
        }

        public void AddMovieAsync(Movie movie)
        {
            context.Movies.Add(movie);
        }

        public void DeleteMovie(Movie movie)
        {
            context.Movies.Remove(movie);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync() >= 0);
        }
    }
}
