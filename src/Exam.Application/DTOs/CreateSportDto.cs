using System.ComponentModel.DataAnnotations;

namespace Exam.Application.DTOs;

public class CreateSportDto
{
    [Required]
    public string Name { get; set; } = null!;
}
