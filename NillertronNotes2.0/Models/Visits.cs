using System;
using System.Collections.Generic;

namespace NillertronNotes.Models
{
    public partial class Visits
    {
        public int Id { get; set; }
        public int? BrugerId { get; set; }
        public string Ip { get; set; }
        public DateTime Dato { get; set; }
    }
}
