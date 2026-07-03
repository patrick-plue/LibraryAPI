namespace LibraryAPI.Models;

public record Author
{
    public Guid Id { get; init; }

    public string? FirstName { get; set; } = string.Empty;

    public required string LastName { get; set; }

    public string? Biography { get; set; }

    public DateOnly? BirthDate { get; set; }

    public DateOnly? DeathDate { get; set; }

}