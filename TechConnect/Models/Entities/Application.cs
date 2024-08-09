using System;
using System.Collections.Generic;

namespace TechConnect.Models.Entities;

public partial class Application
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public int UserId { get; set; }

    public DateTime AppDate { get; set; }

    public string Status { get; set; } = null!;

    public string? Message { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
