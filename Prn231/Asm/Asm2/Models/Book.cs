using System;
using System.Collections.Generic;

namespace Asm2.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int PubId { get; set; }

    public decimal Price { get; set; }

    public string Advance { get; set; } = null!;

    public string Royalty { get; set; } = null!;

    public double Sale { get; set; }

    public string Note { get; set; } = null!;

    public DateTime Publishdate { get; set; }

    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

    public virtual Publisher Pub { get; set; } = null!;
}
