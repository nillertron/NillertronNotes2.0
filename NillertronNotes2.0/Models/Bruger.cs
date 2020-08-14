using System;
using System.Collections.Generic;

namespace NillertronNotes.Models
{
    public partial class Bruger
    {
        public Bruger()
        {
            FagFiler = new HashSet<FagFiler>();
            Noter = new HashSet<Noter>();
            Nyheder = new HashSet<Nyheder>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte Rank { get; set; }
        public string ProfilText { get; set; }

        public virtual ICollection<FagFiler> FagFiler { get; set; }
        public virtual ICollection<Noter> Noter { get; set; }
        public virtual ICollection<Nyheder> Nyheder { get; set; }
    }
}
