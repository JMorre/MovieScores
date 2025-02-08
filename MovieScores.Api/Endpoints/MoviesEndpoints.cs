using MovieScores.Api.Data;
using MovieScores.Api.Dtos;
using MovieScores.Api.Entities;
using MovieScores.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MovieScores.Api.Endpoints;

public static class MoviesEndpoints
{
    const string GetMovieEndpointName = "GetMovie";

    public static RouteGroupBuilder MapMoviesEndpoints(this WebApplication app) 
    {
        var group = app.MapGroup("movies").WithParameterValidation();
        
        // GET /movies
        group.MapGet("/", async (MoviesDBContext dbContext) => 
            await dbContext.Movies.Include(movie => movie.Genre).Select(movie => movie.ToMovieSummaryDto())
            .AsNoTracking().ToListAsync());

        // GET /movies/#
        group.MapGet("/{id}", async (int id, MoviesDBContext dbContext) => 
        {
            Movie? movie = await dbContext.Movies.FindAsync(id);
            return movie is null ? Results.NotFound() : Results.Ok(movie.ToMovieDetailsDto());
        }).WithName(GetMovieEndpointName);

        // POST /movies
        group.MapPost("/", async (CreateMovieDto newMovie, MoviesDBContext dbContext) =>
        {
            Movie movie = newMovie.ToEntity();
            
            dbContext.Movies.Add(movie);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetMovieEndpointName, new {id = movie.Id}, movie.ToMovieDetailsDto());
        });

        //PUT /movies/#
        group.MapPut("/{id}", async (int id, UpdateMovieDto updatedMovie, MoviesDBContext dbContext) =>
        {
            var existingMovie = await dbContext.Movies.FindAsync(id);

            if (existingMovie is null) 
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingMovie).CurrentValues.SetValues(updatedMovie.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        //DELETE /movies/#
        group.MapDelete("/{id}", async (int id, MoviesDBContext dbContext) =>
        {
            await dbContext.Movies.Where(movie => movie.Id == id).ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
