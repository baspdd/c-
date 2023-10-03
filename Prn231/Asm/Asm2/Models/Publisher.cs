using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Asm2.Models;

public partial class Publisher
{
    public int PubId { get; set; }

    public string? PubName { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
