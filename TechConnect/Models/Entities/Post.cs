using System;
using System.Collections.Generic;

namespace TechConnect.Models.Entities;

public partial class Post
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual User? User { get; set; }

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
