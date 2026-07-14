using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Dtos.Books;

public record CreateBookDto([property: Required] string Title, [property: Required] Guid AuthorId, string? Isbn, string? Description, int? PublishedYear, string? Genre, int? PageCount);
