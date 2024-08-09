using System;
using System.Collections.Generic;

namespace TechConnect.Models.Entities;

public partial class Skill
{
    public int Id { get; set; }

    public string SkillName { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
