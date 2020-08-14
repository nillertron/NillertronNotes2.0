using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NillertronNotes.Models
{
    public partial class Noter
    {
        public int Id { get; set; }
        [Required]
        public string Overskrift { get; set; }
        [Required]
        public string NoteText { get; set; } = string.Empty;
        public DateTime Skrevet { get; set; } = DateTime.Now;
        public int BrugerId { get; set; }
        public int FagId { get; set; }

        public virtual Bruger Bruger { get; set; }
        public virtual Fag Fag { get; set; }
    }
}
