using LibraryAPI.Models;

namespace LibraryAPI.Application.Interface;

public interface IBookService
{

    public Book AddBook(string title, Guid authorId, string? isbn, string? description, int? publishedYear, string? genre, int? pageCount);

    public bool RemoveBook(Guid id);

    public IReadOnlyCollection<Book> ListBooks();

    public Book? GetBookById(Guid id);

    public Book? UpdateBook(Guid id, string? title, Guid? authorId, string? isbn, string? description, int? publishedYear, string? genre, int? pageCount);

}