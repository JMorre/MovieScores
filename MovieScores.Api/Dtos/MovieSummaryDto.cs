namespace MovieScores.Api.Dtos;

public record class MovieSummaryDto(
    int Id, 
    string Title, 
    string Genre, 
    DateOnly ReleaseDate,
    int Score
);