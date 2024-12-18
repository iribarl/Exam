using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Exam.Domain.Common
{
    public class PaginationParam : IValidatableObject
    {
        [Required]
        public int pageNumber { get; set; }

        [Required, DefaultValue(100), Range(10, 300)]
        public int pageSize { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (pageNumber < 0)
                yield return new ValidationResult("Page number cannot be negative value.", new[] { nameof(pageNumber) });

        }
    }
}
