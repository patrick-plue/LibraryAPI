namespace LibraryAPI.Models;

public class Book
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public required string Title { get; set; } = string.Empty;

    public required Guid AuthorId { get; set; }

    public string? ISBN { get; set; }

    public string? Description { get; set; }

    public DateOnly? PublishedDate { get; set; }

    public string? Genre { get; set; }

    public int PageCount { get; set; }

    public string? Language { get; set; }

}