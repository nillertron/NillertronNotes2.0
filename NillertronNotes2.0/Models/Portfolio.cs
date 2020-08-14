using System;
using System.Collections.Generic;

namespace NillertronNotes.Models
{
    public partial class Portfolio
    {
        public Portfolio()
        {
            Picture = new HashSet<Picture>();
        }

        public int Id { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public DateTime Published { get; set; }

        public virtual ICollection<Picture> Picture { get; set; }
    }
}
