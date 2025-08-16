using System;
using System.Collections.Generic;

namespace OwlyNest.Core.Models;

public partial class Url
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string ShortCode { get; set; } = null!;

    public string OriginalUrl { get; set; } = null!;

    public string Title { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ExpiredAt { get; set; }

    public bool IsActive { get; set; }

    public int ClickCount { get; set; }

    public virtual ICollection<Click> Clicks { get; set; } = new List<Click>();

    public virtual User User { get; set; } = null!;
}
