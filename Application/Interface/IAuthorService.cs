using LibraryAPI.Models;

namespace LibraryAPI.Application.Interface;

public interface IAuthorService
{
    public Author AddAuthor(string? firstName, string lastName, string? biography, DateOnly? BirthDate, DateOnly? DeathDate);

    public bool RemoveAuthor(Guid id);

    public IReadOnlyCollection<Author> ListAuthors();

    public Author? GetAuthorById(Guid id);

    public Author? UpdateAuthor(Guid id, string? firstName, string? lastName, string? biography, DateOnly? BirthDate, DateOnly? DeathDate);

}