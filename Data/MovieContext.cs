using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Data;

// shorthand for creating class MovieContext : DbContext and then using a constructor within it
public class MovieContext(DbContextOptions<MovieContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies {get; set;}
    public DbSet<Review> Reviews {get; set;}

    // method for seeding data to database
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Review>().HasData(
            new Review {Id = 1, ReviewerName="Taran Adarsh", Comment = "Very good movie.", Rating = 8, MovieId = 1},
            new Review {Id = 2, ReviewerName = "Bob", Comment = "Amazing visuals and story.", Rating = 6, MovieId = 1 },
            new Review {Id = 3, ReviewerName = "Charlie", Comment = "Best superhero movie ever!", Rating = 7, MovieId = 2 }
        );

        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "Inception", Director = "Christopher Nolan", ReleaseDate = new DateOnly(2003, 1, 1) },
            new Movie { Id = 2, Title = "The Dark Knight", Director = "Christopher Nolan", ReleaseDate = new DateOnly(2008, 7, 18) },
            new Movie { Id = 3, Title = "Dangal", Director = "Nitesh Tiwari", ReleaseDate = new DateOnly(2016, 12, 18) }
        );
    }
}