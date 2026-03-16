using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentsClassLib.Models;

public partial class StudentPortalDbContext : DbContext
{
    public StudentPortalDbContext()
    {
    }

    public StudentPortalDbContext(DbContextOptions<StudentPortalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())", "DF_Students_CreatedAt");
            entity.Property(e => e.Status).HasDefaultValue("Active", "DF_Students_Status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
