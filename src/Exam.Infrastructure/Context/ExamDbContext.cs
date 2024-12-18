using System;
using System.Collections.Generic;
using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Infrastructure.Context;

public partial class ExamDbContext : DbContext
{
    public ExamDbContext()
    {
    }

    public ExamDbContext(DbContextOptions<ExamDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<League> Leagues { get; set; }

    public virtual DbSet<Sport> Sports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Event__3214EC079A8E8E1C");

            entity.ToTable("Event");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Name).UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<League>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__League__3214EC07536567FC");

            entity.ToTable("League");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Sport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sport__3214EC074CE4960E");

            entity.ToTable("Sport");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
