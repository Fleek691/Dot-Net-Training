using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentsClassLib.Models;

[Index("Email", Name = "UX_Students_Email", IsUnique = true)]
public partial class Student
{
    [Key]
    public int StudentId { get; set; }

    [StringLength(120)]
    public string FullName { get; set; } = null!;

    [StringLength(180)]
    public string Email { get; set; } = null!;

    [StringLength(30)]
    public string? Phone { get; set; }

    [StringLength(20)]
    public string Status { get; set; } = null!;

    public DateOnly JoinDate { get; set; }

    public DateTime CreatedAt { get; set; }
}
