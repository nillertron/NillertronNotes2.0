using System;
using System.Collections.Generic;

namespace NillertronNotes.Models
{
    public partial class Nyheder
    {
        public int Id { get; set; }
        public int BrugerId { get; set; }
        public string Overskrift { get; set; }
        public string Text { get; set; }
        public DateTime SkrevetDato { get; set; }
        public string BilledeUrl { get; set; }

        public virtual Bruger Bruger { get; set; }
    }
}
