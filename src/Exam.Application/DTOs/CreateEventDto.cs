using System.ComponentModel.DataAnnotations;

namespace Exam.Application.DTOs;

public class CreateEventDto
{
    [Required, Range(0, long.MaxValue)]
    public long LeagueId { get; set; }

    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }
}
