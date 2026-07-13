namespace LibraryAPI.Dtos.Books;

public record UpdateBookDto(string? Title, Guid? AuthorId, string? Isbn, string? Description, int? PublishedYear, string? Genre, int? PageCount);
