using LibraryAPI.Application.Interface;
using LibraryAPI.Dtos.Authors;
using LibraryAPI.Dtos.Books;
using LibraryAPI.Models;

public static class AuthorEndpoints
{
    public static void MapAuthors(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/authors");

        group.MapGet("/", (IAuthorService authorService) =>
        {

            var authors = authorService.ListAuthors();
            var authorDtos = authors.Select(a => new AuthorResponseDto(a.Id, a.FirstName, a.LastName, a.Biography, a.BirthDate, a.DeathDate));

            return Results.Ok(authorDtos);
        });


        group.MapGet("/{id:guid}/book", (Guid id, IBookService bookService, IAuthorService authorService) =>
        {
            var author = authorService.GetAuthorById(id);

            if (author == null)
                return Results.NotFound();

            var books = bookService.ListBooks();

            var booksByAuthorDto = books.Where(b => b.AuthorId == id).Select(b => new BookResponseDto(b.Id, b.Title, b.AuthorId, b.Isbn, b.Description, b.PublishedYear, b.Genre, b.PageCount));

            return Results.Ok(booksByAuthorDto);

        });

        group.MapPost("/", (CreateAuthorDto createAuthorDto, IAuthorService authorService, HttpContext context) =>
        {
            try
            {
                var author = authorService.AddAuthor(createAuthorDto.FirstName, createAuthorDto.LastName, createAuthorDto.Biography, createAuthorDto.BirthDate, createAuthorDto.DeathDate);

                var authorDto = new AuthorResponseDto(author.Id, author.FirstName, author.LastName, author.Biography, author.BirthDate, author.DeathDate);

                var location = $"{context.Request.Scheme}://{context.Request.Host}/authors/{author.Id}";

                return Results.Created(location, authorDto);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.Message);
            }
        });


        group.MapPatch("/{id:guid}", (Guid id, UpdateAuthorDto updateAuthorDto, IAuthorService authorService) =>
        {
            var author = authorService.UpdateAuthor(id, updateAuthorDto.FirstName, updateAuthorDto.LastName, updateAuthorDto.Biography, updateAuthorDto.BirthDate, updateAuthorDto.DeathDate);

            if (author == null)
                return Results.NotFound();

            var authorDto = new AuthorResponseDto(author.Id, author.FirstName, author.LastName, author.Biography, author.BirthDate, author.DeathDate);

            return Results.Ok(authorDto);
        });

        group.MapDelete("/{id:guid}", (Guid id, IAuthorService authorService) =>
        {
            var deleted = authorService.RemoveAuthor(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        });

    }
}