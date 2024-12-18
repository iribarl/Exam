using System.ComponentModel.DataAnnotations;

namespace Exam.Application.DTOs;

public class LeagueDto
{
    [Range(0, long.MaxValue)]
    public long Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Required, Range(0, int.MaxValue)]
    public int SportId { get; set; }
}
