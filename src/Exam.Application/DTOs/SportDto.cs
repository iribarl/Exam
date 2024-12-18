using System.ComponentModel.DataAnnotations;

namespace Exam.Application.DTOs;

public class SportDto
{
    [Required, Range(0, int.MaxValue)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}
