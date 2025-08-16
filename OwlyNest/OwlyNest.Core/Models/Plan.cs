using System;
using System.Collections.Generic;

namespace OwlyNest.Core.Models;

public partial class Plan
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal PriceUsd { get; set; }

    public decimal? PriceYearlyUsd { get; set; }

    public int MaxUrls { get; set; }

    public int MaxClicks { get; set; }

    public bool CustomDomains { get; set; }

    /// <summary>
    /// E = email, C = chat, D =dedicado
    /// </summary>
    public string SupportLevel { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
