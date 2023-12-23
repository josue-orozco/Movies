using Microsoft.EntityFrameworkCore;
using Movies.API.Common;
using Movies.API.Entities;

namespace Movies.API.DbContexts
{
    public class MoviesContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Entities.Genre> Genres { get; set; } = null!;
        public DbSet<Actor> Actors {get; set; } = null!;

        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Movie>()
            //    .HasMany(e => e.Genres)
            //    .WithOne(e => e.Movie)
            //    .HasForeignKey(e => e.MovieId)
            //    .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<Movie>()
                .HasData(
                new Movie("The Shawshank Redemption")
                {
                    Id = 1,
                    Director = "Frank Darabont",
                    Rating = Rating.R,
                    Duration = 142,
                    ReleaseYear = 1994,
                    Description =   "Over the course of several years, two convicts form a friendship, " +
                                    "seeking consolation and, eventually, redemption through basic compassion."
                },
                new Movie("The Godfather")
                {
                    Id = 2,
                    Director = "Francis Ford Coppola",
                    Rating = Rating.R,
                    Duration = 175,
                    ReleaseYear = 1972,
                    Description =   "Don Vito Corleone, head of a mafia family, decides to hand over his empire " +
                                    "to his youngest son Michael. However, his decision unintentionally puts the " +
                                    "lives of his loved ones in grave danger."
                },
                new Movie("The Dark Knight")
                {
                    Id = 3,
                    Director = "Christopher Nolan",
                    Rating = Rating.R,
                    Duration = 152,
                    ReleaseYear = 2008,
                    Description =   "When the menace known as the Joker wreaks havoc and chaos on the people of " +
                                    "Gotham, Batman must accept one of the greatest psychological and physical tests " +
                                    "of his ability to fight injustice."
                });

            modelBuilder.Entity<Entities.Genre>()
                .HasData(
                new Entities.Genre
                {
                    Id = 1,
                    MovieId = 1,
                    MovieGenre = Common.Genre.Drama
                },
                new Entities.Genre
                {
                    Id = 2,
                    MovieId = 2,
                    MovieGenre = Common.Genre.Drama
                },
                new Entities.Genre
                {
                    Id = 3,
                    MovieId = 2,
                    MovieGenre = Common.Genre.Crime
                },
                new Entities.Genre
                {
                    Id = 4,
                    MovieId = 3,
                    MovieGenre = Common.Genre.Action
                },
                new Entities.Genre
                {
                    Id = 5,
                    MovieId = 3,
                    MovieGenre = Common.Genre.Drama
                },
                new Entities.Genre
                {
                    Id = 6,
                    MovieId = 3,
                    MovieGenre = Common.Genre.Crime
                },
                new Entities.Genre
                {
                    Id = 7,
                    MovieId = 3,
                    MovieGenre = Common.Genre.Thriller
                });

            modelBuilder.Entity<Actor>()
                .HasData(
                new Actor
                {
                    Id = 1,
                    MovieId = 1,
                    FirstName = "Tim",
                    LastName = "Robbins"
                },
                new Actor
                {
                    Id = 2,
                    MovieId = 1,
                    FirstName = "Morgan",
                    LastName = "Freeman"
                },
                new Actor
                {
                    Id = 3,
                    MovieId = 2,
                    FirstName = "Marlon",
                    LastName = "Brando"
                },
                new Actor
                {
                    Id = 4,
                    MovieId = 2,
                    FirstName = "Al",
                    LastName = "Pacino"
                },
                new Actor
                {
                    Id = 5,
                    MovieId = 2,
                    FirstName = "James",
                    LastName = "Caan"
                },
                new Actor
                {
                    Id = 6,
                    MovieId = 3,
                    FirstName = "Christian",
                    LastName = "Bale"
                },
                new Actor
                {
                    Id = 7,
                    MovieId = 3,
                    FirstName = "Heath",
                    LastName = "Ledger"
                });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
