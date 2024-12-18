using System.ComponentModel.DataAnnotations;

namespace Exam.Application.DTOs;

public class CreateLeagueDto
{
    [Required]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Required, Range(0, int.MaxValue)]
    public int SportId { get; set; }
}
