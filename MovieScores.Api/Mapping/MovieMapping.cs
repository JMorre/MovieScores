using MovieScores.Api.Dtos;
using MovieScores.Api.Entities;

namespace MovieScores.Api.Mapping;

public static class MovieMapping
{
    public static Movie ToEntity(this CreateMovieDto movie)
    {
        return new()
            {
                Title = movie.Title,
                GenreId = movie.GenreId,
                ReleaseDate = movie.ReleaseDate,
                Score = movie.Score
            };
    }

    public static MovieSummaryDto ToMovieSummaryDto(this Movie movie)
    {
        return new(movie.Id, movie.Title, movie.Genre!.Name, movie.ReleaseDate, movie.Score);
    }

    public static MovieDetailsDto ToMovieDetailsDto(this Movie movie)
    {
        return new(movie.Id, movie.Title, movie.GenreId, movie.ReleaseDate, movie.Score);
    }

    public static Movie ToEntity(this UpdateMovieDto movie, int id)
    {
        return new()
            {
                Id = id,
                Title = movie.Title,
                GenreId = movie.GenreId,
                ReleaseDate = movie.ReleaseDate,
                Score = movie.Score
            };
    }
}
