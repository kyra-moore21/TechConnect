using System;
using System.Collections.Generic;

namespace TechConnect.Models.Entities;

public partial class SocialLink
{
    public int Id { get; set; }

    public int UserProfileId { get; set; }

    public string? Link { get; set; }

    public int SocialMediaTypeId { get; set; }

    public virtual SocialMediaType SocialMediaType { get; set; } = null!;

    public virtual Userprofile UserProfile { get; set; } = null!;
}
