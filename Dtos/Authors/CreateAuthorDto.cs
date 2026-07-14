
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Dtos.Authors;

public record CreateAuthorDto(string? FirstName, [property: Required][property: StringLength(100, MinimumLength = 1)] string LastName, string? Biography, DateOnly? BirthDate, DateOnly? DeathDate);