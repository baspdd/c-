using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class AccountDTO
{
    public string AccountId { get; set; } = null!;

    public string? FullName { get; set; }

}
