using System;
using System.Collections.Generic;

namespace Exam.Domain.Entities;

public partial class Event
{
    public long Id { get; set; }

    public long LeagueId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual League League { get; set; } = null!;
}
