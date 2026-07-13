namespace LibraryAPI.Dtos.Books;

public record CreateBookDto(string Title, Guid AuthorId, string? Isbn, string? Description, int? PublishedYear, string? Genre, int? PageCount);
