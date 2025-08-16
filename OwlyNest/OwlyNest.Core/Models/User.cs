using System;
using System.Collections.Generic;

namespace OwlyNest.Core.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public int PlanId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime LastLogin { get; set; }

    public bool? IsActive { get; set; }

    public virtual Plan Plan { get; set; } = null!;

    public virtual ICollection<Url> Urls { get; set; } = new List<Url>();
}
