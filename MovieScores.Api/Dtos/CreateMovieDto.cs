using System.ComponentModel.DataAnnotations;

namespace MovieScores.Api.Dtos;

public record class CreateMovieDto(
    [Required][StringLength(100)] string Title, 
    int GenreId,
    DateOnly ReleaseDate,
    int Score
);