using System;
using System.Collections.Generic;

namespace NillertronNotes.Models
{
    public partial class Fag
    {
        public Fag()
        {
            FagFiler = new HashSet<FagFiler>();
            Noter = new HashSet<Noter>();
        }

        public int Id { get; set; }
        public string Fag1 { get; set; }

        public virtual ICollection<FagFiler> FagFiler { get; set; }
        public virtual ICollection<Noter> Noter { get; set; }
    }
}
