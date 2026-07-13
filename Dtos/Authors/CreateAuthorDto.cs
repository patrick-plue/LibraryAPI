
namespace LibraryAPI.Dtos.Authors;

public record CreateAuthorDto(string? FirstName, string LastName, string? Biography, DateOnly? BirthDate, DateOnly? DeathDate);