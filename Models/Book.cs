namespace LibraryAPI.Models;

public record Book
{
    public Guid Id { get; init; }
    public required string Title { get; set; }
    public required Guid AuthorId { get; set; }
    public string? Isbn { get; set; }
    public string? Description { get; set; }
    public int? PublishedYear { get; set; }
    public string? Genre { get; set; }
    public int? PageCount { get; set; }
}