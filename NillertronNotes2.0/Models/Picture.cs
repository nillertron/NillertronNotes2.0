using System;
using System.Collections.Generic;

namespace NillertronNotes.Models
{
    public partial class Picture
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int PortfolioId { get; set; }

        public virtual Portfolio Portfolio { get; set; }
    }
}
