namespace LibraryAPI.Dtos.Authors;

public record UpdateAuthorDto(string? FirstName, string? LastName, string? Biography, DateOnly? BirthDate, DateOnly? DeathDate);