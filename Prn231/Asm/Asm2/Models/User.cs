using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Asm2.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Source { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public int? RoleId { get; set; }

    public int? PubId { get; set; }

    public DateTime? HireDate { get; set; }

    [JsonIgnore]
    public virtual Publisher? Pub { get; set; }
    [JsonIgnore]
    public virtual Role? Role { get; set; }
}
