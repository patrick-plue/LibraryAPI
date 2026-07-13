using LibraryAPI.Application.Interface;
using LibraryAPI.Models;

namespace LibraryAPI.Application.Services;

public class InMemoryBookService : IBookService
{
    private readonly Dictionary<Guid, Book> _books = new();


    public Book AddBook(string title, Guid authorId, string? isbn, string? description, int? publishedYear, string? genre, int? pageCount)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required", nameof(title));

        Book newBook = new Book
        {
            Id = Guid.NewGuid(),
            Title = title,
            AuthorId = authorId,
            Isbn = isbn,
            Description = description,
            PublishedYear = publishedYear,
            Genre = genre,
            PageCount = pageCount
        };

        _books.TryAdd(newBook.Id, newBook);

        return newBook;
    }

    public bool RemoveBook(Guid id)
    {
        if (!_books.Remove(id, out var removed))
            return false;

        return true;
    }

    public IReadOnlyCollection<Book> ListBooks() => _books.Values.ToList();

    public Book? GetBookById(Guid id) => _books.TryGetValue(id, out var book) ? book : null;

    public Book? UpdateBook(Guid id, string? title, Guid? authorId, string? isbn, string? description, int? publishedYear, string? genre, int? pageCount)
    {
        if (!_books.TryGetValue(id, out var book))
            return null;
        if (title is not null) book.Title = title;
        if (isbn is not null) book.Isbn = isbn;
        if (description is not null) book.Description = description;
        if (publishedYear is not null) book.PublishedYear = publishedYear;
        if (genre is not null) book.Genre = genre;
        if (pageCount is not null) book.PageCount = pageCount;
        return book;
    }
}