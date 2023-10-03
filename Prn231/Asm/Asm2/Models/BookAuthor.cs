using System;
using System.Collections.Generic;

namespace Asm2.Models;

public partial class BookAuthor
{
    public int AuthorId { get; set; }

    public int BookId { get; set; }

    public string AuthorOrder { get; set; } = null!;

    public double? Royaltypercent { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;
}
