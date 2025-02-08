namespace MovieScores.Api.Dtos;

public record class MovieDetailsDto(
    int Id,
    string Title,
    int GenreId,
    DateOnly ReleaseDate,
    int Score
);