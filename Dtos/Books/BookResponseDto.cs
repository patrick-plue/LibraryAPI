namespace LibraryAPI.Dtos.Books;

public record BookResponseDto(Guid id, string Title, Guid AuthorId, string? Isbn, string? Description, int? PublishedYear, string? Genre, int? PageCount);
