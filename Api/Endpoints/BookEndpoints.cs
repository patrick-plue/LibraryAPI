using LibraryAPI.Application.Interface;
using LibraryAPI.Dtos.Books;
using LibraryAPI.Filters;

public static class BookEndpoints
{
    public static void MapBooks(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/books");

        group.MapGet("/", (IBookService bookService) =>
        {
            var books = bookService.ListBooks();
            var bookDtos = books.Select(b => new BookResponseDto(b.Id, b.Title, b.AuthorId, b.Isbn, b.Description, b.PublishedYear, b.Genre, b.PageCount));
            return Results.Ok(bookDtos);
        });


        group.MapPost("/", (CreateBookDto createBookDto, IBookService bookService, HttpContext context) =>
        {
            try
            {
                var book = bookService.AddBook(createBookDto.Title, createBookDto.AuthorId, createBookDto.Isbn, createBookDto.Description, createBookDto.PublishedYear, createBookDto.Genre, createBookDto.PageCount);

                var bookDto = new BookResponseDto(book.Id, book.Title, book.AuthorId, book.Isbn, book.Description, book.PublishedYear, book.Genre, book.PageCount);

                var location = $"{context.Request.Scheme}://{context.Request.Host}/books/{book.Id}";

                return Results.Created(location, bookDto);


            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.Message);
            }
        }).WithValidation<CreateBookDto>();


        group.MapPatch("/{id:guid}", (Guid id, UpdateBookDto updateBookDto, IBookService bookService) =>
        {
            var book = bookService.UpdateBook(id, updateBookDto.Title, updateBookDto.AuthorId, updateBookDto.Isbn, updateBookDto.Description, updateBookDto.PublishedYear, updateBookDto.Genre, updateBookDto.PageCount);


            if (book == null)
                return Results.NotFound();

            var bookDto = new BookResponseDto(book.Id, book.Title, book.AuthorId, book.Isbn, book.Description, book.PublishedYear, book.Genre, book.PageCount);

            return Results.Ok(bookDto);


        });


        group.MapDelete("/{id:guid}", (Guid id, IBookService bookService) =>
        {
            var deleted = bookService.RemoveBook(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        });
    }
}