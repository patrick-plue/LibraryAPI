using LibraryAPI.Application.Interface;
using LibraryAPI.Models;

namespace LibraryAPI.Application.Services;


public class InMemoryAuthorService : IAuthorService
{

    private readonly Dictionary<Guid, Author> _authors = new();

    public Author AddAuthor(string? firstName, string lastName, string? biography, DateOnly? birthDate, DateOnly? deathDate)
    {
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("LastName is required", nameof(lastName));

        Author newAuthor = new Author
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Biography = biography,
            BirthDate = birthDate,
            DeathDate = deathDate
        };

        _authors.TryAdd(newAuthor.Id, newAuthor);

        return newAuthor;
    }

    public bool RemoveAuthor(Guid id)
    {

        if (!_authors.Remove(id, out var removed))
            return false;

        return true;

    }

    public IReadOnlyCollection<Author> ListAuthors() => _authors.Values.ToList();

    public Author? GetAuthorById(Guid id) => _authors.TryGetValue(id, out var author) ? author : null;

    public Author? UpdateAuthor(Guid id, string? firstName, string? lastName, string? biography, DateOnly? birthDate, DateOnly? deathDate)
    {

        if (!_authors.TryGetValue(id, out var author))
            return null;
        if (firstName is not null) author.FirstName = firstName;
        if (lastName is not null) author.LastName = lastName;
        if (biography is not null) author.Biography = biography;
        if (birthDate is not null) author.BirthDate = birthDate;
        if (deathDate is not null) author.DeathDate = deathDate;
        return author;
    }

}