using System;
using System.Collections.Generic;

namespace Exam.Domain.Entities;

public partial class League
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int SportId { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Sport Sport { get; set; } = null!;
}
