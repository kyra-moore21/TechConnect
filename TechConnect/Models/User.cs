using System;
using System.Collections.Generic;

namespace TechConnect.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirebaseId { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual Userprofile? Userprofile { get; set; }

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
