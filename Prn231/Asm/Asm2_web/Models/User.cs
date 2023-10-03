using System;
using System.Collections.Generic;

namespace Asm2_web.Models;

public partial class User
{
    public int userId { get; set; }

    public string email { get; set; } = null!;

    public string password { get; set; } = null!;

    public string? source { get; set; }

    public string? firstName { get; set; }

    public string? middleName { get; set; }

    public string? lastName { get; set; }

    public int? roleId { get; set; }

    public int? pubId { get; set; }

    public DateTime? hireDate { get; set; }

}
