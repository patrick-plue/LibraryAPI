using LibraryAPI.Models;

namespace LibraryAPI.Application.Interface;

public interface IBookService
{

    public Book AddBook(string title, Guid authorId, string? isbn, string? description, DateOnly? publishedDate, string? genre, int? pageCount);

    public bool RemoveBook(Guid id);

    public IEnumerable<Book>? ListBooks();

    public Book? GetBookById(Guid id);

    public Book? UpdateBook(Guid id, string? title, string? isbn, string? description, DateOnly? publishedDate, string? genre, int? pageCount);

}