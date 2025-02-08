using MovieScores.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace MovieScores.Api.Data;

public class MoviesDBContext(DbContextOptions<MoviesDBContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies => Set<Movie>();

    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new {Id = 1, Name = "Adventure"},
            new {Id = 2, Name = "Action"},
            new {Id = 3, Name = "Drama"},
            new {Id = 4, Name = "Comedy"},
            new {Id = 5, Name = "Thriller"},
            new {Id = 6, Name = "Horror"},
            new {Id = 7, Name = "Documentary"}
        );
    }
}
