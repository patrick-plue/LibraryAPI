namespace LibraryAPI.Dtos.Authors;

public record AuthorResponseDto(Guid id, string? FirstName, string LastName, string? Biography, DateOnly? BirthDate, DateOnly? DeathDate);