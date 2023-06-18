using System;
using System.Collections.Generic;

namespace SignalRAssignment.Models
{
    public partial class Account
    {
        public string AccountId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? FullName { get; set; }
        public bool Type { get; set; }
    }
}
