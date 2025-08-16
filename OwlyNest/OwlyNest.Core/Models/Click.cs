using System;
using System.Collections.Generic;

namespace OwlyNest.Core.Models;

public partial class Click
{
    public int Id { get; set; }

    public int UrlId { get; set; }

    public DateTime ClickedAt { get; set; }

    public string IpAddress { get; set; } = null!;

    public string UserAgent { get; set; } = null!;

    public string? Referrer { get; set; }

    public string Contry { get; set; } = null!;

    public virtual Url Url { get; set; } = null!;
}
