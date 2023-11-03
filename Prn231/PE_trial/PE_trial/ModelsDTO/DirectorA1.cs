using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PE_trial.ModelsDTO
{
    public partial class DirectorA1
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public bool Male { get; set; }
        public DateTime Dob { get; set; }
        public string Nationality { get; set; } = null!;
        public string Description { get; set; } = null!;

    }
}
