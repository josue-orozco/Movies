﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movies.API.DbContexts;

#nullable disable

namespace Movies.API.Migrations
{
    [DbContext(typeof(MoviesContext))]
    [Migration("20231217041151_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Movies.API.Entities.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Tim",
                            LastName = "Robbins",
                            MovieId = 1
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Morgan",
                            LastName = "Freeman",
                            MovieId = 1
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Marlon",
                            LastName = "Brando",
                            MovieId = 2
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Al",
                            LastName = "Pacino",
                            MovieId = 2
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "James",
                            LastName = "Caan",
                            MovieId = 2
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Christian",
                            LastName = "Bale",
                            MovieId = 3
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "Heath",
                            LastName = "Ledger",
                            MovieId = 3
                        });
                });

            modelBuilder.Entity("Movies.API.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MovieGenre")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MovieGenre = 1,
                            MovieId = 1
                        },
                        new
                        {
                            Id = 2,
                            MovieGenre = 1,
                            MovieId = 2
                        },
                        new
                        {
                            Id = 3,
                            MovieGenre = 0,
                            MovieId = 2
                        },
                        new
                        {
                            Id = 4,
                            MovieGenre = 14,
                            MovieId = 3
                        },
                        new
                        {
                            Id = 5,
                            MovieGenre = 1,
                            MovieId = 3
                        },
                        new
                        {
                            Id = 6,
                            MovieGenre = 0,
                            MovieId = 3
                        },
                        new
                        {
                            Id = 7,
                            MovieGenre = 11,
                            MovieId = 3
                        });
                });

            modelBuilder.Entity("Movies.API.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.",
                            Director = "Frank Darabont",
                            Duration = 142,
                            Rating = 3,
                            ReleaseYear = 1994,
                            Title = "The Shawshank Redemption"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Don Vito Corleone, head of a mafia family, decides to hand over his empire to his youngest son Michael. However, his decision unintentionally puts the lives of his loved ones in grave danger.",
                            Director = "Francis Ford Coppola",
                            Duration = 175,
                            Rating = 3,
                            ReleaseYear = 1972,
                            Title = "The Godfather"
                        },
                        new
                        {
                            Id = 3,
                            Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                            Director = "Christopher Nolan",
                            Duration = 152,
                            Rating = 3,
                            ReleaseYear = 2008,
                            Title = "The Dark Knight"
                        });
                });

            modelBuilder.Entity("Movies.API.Entities.Actor", b =>
                {
                    b.HasOne("Movies.API.Entities.Movie", "Movie")
                        .WithMany("Cast")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Movies.API.Entities.Genre", b =>
                {
                    b.HasOne("Movies.API.Entities.Movie", "Movie")
                        .WithMany("Genres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Movies.API.Entities.Movie", b =>
                {
                    b.Navigation("Cast");

                    b.Navigation("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}