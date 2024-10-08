﻿using System;
using System.Collections.Generic;

namespace TechConnect.Models.Entities;

public partial class Userprofile
{
    public int Userid { get; set; }

    public string? AboutMe { get; set; }

    public string? ProfilePicture { get; set; }

    public List<string> SocialLinks { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
