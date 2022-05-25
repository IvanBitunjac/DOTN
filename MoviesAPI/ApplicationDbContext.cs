using Microsoft.EntityFrameworkCore;
using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var adventure = new Genre() { Id = 4, Name = "Adventure" };
            var animation = new Genre() { Id = 5, Name = "Animation" };
            var drama = new Genre() { Id = 6, Name = "Drama" };
            var romance = new Genre() { Id = 7, Name = "Romance" };

            modelBuilder.Entity<Genre>()
                .HasData(new List<Genre>
                {
                    adventure, animation, drama, romance
                });

            var actor1 = new Actor() { Id = 5, Name = "Test Test", DateOfBirth = new DateTime(1962, 01, 17) };
            var actor2 = new Actor() { Id = 6, Name = "Test1 Test1", DateOfBirth = new DateTime(1965, 4, 4) };
            var actor3 = new Actor() { Id = 7, Name = "Test2 Test2", DateOfBirth = new DateTime(1981, 06, 13) };

            modelBuilder.Entity<Actor>()
                .HasData(new List<Actor>
                {
                    actor1, actor2, actor3
                });

            var movie1 = new Movie()
            {
                Id = 2,
                Title = "Movie1",
                ActorId = 5,
                GenreId=4
            };

            var movie2 = new Movie()
            {
                Id = 3,
                Title = "Movie2",
                ActorId = 6,
                GenreId = 5
            };

     
        
            modelBuilder.Entity<Movie>()
                .HasData(new List<Movie>
                {
                    movie1, movie2
                });
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }

    }
}
