using Movies.API.Common;
using Movies.API.Models;

namespace Movies.API
{
    public class MoviesDataStore
    {
        public List<MovieDto> Movies { get; set; }

        public MoviesDataStore()
        {
            //ActorDto MarlonBrando =
            //new ActorDto()
            //{
            //    FirstName = "Marlon",
            //    LastName = "Brando",
            //};

            Movies = new List<MovieDto>()
            {
                new MovieDto()
                {
                    Title = "The Godfather",
                    Director = "Francis Ford Coppola",
                    Rating = Rating.R,
                    Duration = 175,
                    Genre = new List<Genre>()
                    {
                        Genre.Crime,
                        Genre.Drama
                    },
                    Cast = new List<ActorDto>()
                    {
                        //MarlonBrando,
                        new ActorDto()
                        {
                            FirstName = "Marlon",
                            LastName = "Brando",
                        },
                        new ActorDto()
                        {
                            FirstName = "Al",
                            LastName = "Pacino",
                        },
                        new ActorDto()
                        {
                            FirstName = "James",
                            LastName = "Caan",
                        }
                    },
                    ReleaseYear = 1972,
                    Description =   "The aging patriarch of an organized crime dynasty in postwar" +
                                    "New York City transfers control of his clandestine empire to " +
                                    "his reluctant youngest son."
                },
                new MovieDto()
                {
                    Title = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    Rating = Rating.R,
                    Duration = 142,
                    Genre = new List<Genre>()
                    {
                        Genre.Drama
                    },
                    Cast = new List<ActorDto>()
                    {
                        new ActorDto()
                        {
                            FirstName = "Tim",
                            LastName = "Robbins",
                        },
                        new ActorDto()
                        {
                            FirstName = "Morgan",
                            LastName = "Freeman",
                        },
                        new ActorDto()
                        {
                            FirstName = "Bob",
                            LastName = "Gunton",
                        }
                    },
                    ReleaseYear = 1994,
                    Description =   "Two imprisoned men bond over a number of years, finding solace and" +
                                    "eventual redemption through acts of common decency."
                },
                new MovieDto()
                {
                    Title = "Schindler's List",
                    Director = "Steven Spielberg",
                    Rating = Rating.R,
                    Duration = 195,
                    Genre = new List<Genre>()
                    {
                        Genre.Biography,
                        Genre.Drama,
                        Genre.History
                    },
                    Cast = new List<ActorDto>()
                    {
                        new ActorDto()
                        {
                            FirstName = "Liam",
                            LastName = "Neeson",
                        },
                        new ActorDto()
                        {
                            FirstName = "Ralph",
                            LastName = "Fiennes",
                        },
                        new ActorDto()
                        {
                            FirstName = "Ben",
                            LastName = "Kingsley",
                        }
                    },
                    ReleaseYear = 1993,
                    Description =   "In German-occupied Poland during World War II, industrialist Oskar" +
                                    "Schindler gradually becomes concerned for his Jewish workforce after" +
                                    "witnessing their persecution by the Nazis."
                }
            };
        }
    }
}
