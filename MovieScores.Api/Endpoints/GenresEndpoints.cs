using MovieScores.Api.Data;
using MovieScores.Api.Entities;
using MovieScores.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MovieScores.Api.Endpoints;

public static class GenresEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("genres");

        group.MapGet("/", async (MoviesDBContext dbContext) => 
            await dbContext.Genres.Select(genre => genre.ToDto()).AsNoTracking().ToListAsync());
        
        return group;
    }
}
