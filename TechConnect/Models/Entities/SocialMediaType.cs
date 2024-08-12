using System;
using System.Collections.Generic;

namespace TechConnect.Models.Entities;

public partial class SocialMediaType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public virtual ICollection<SocialLink> SocialLinks { get; set; } = new List<SocialLink>();
}
