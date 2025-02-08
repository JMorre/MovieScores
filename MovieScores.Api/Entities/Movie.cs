namespace MovieScores.Api.Entities;

public class Movie
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public int GenreId { get; set; }

    public Genre? Genre { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public int Score { get; set; }
}
