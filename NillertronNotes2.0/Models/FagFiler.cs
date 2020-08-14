using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NillertronNotes.Models
{
    public partial class FagFiler
    {
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public int FagId { get; set; }
        [Required]
        public int BrugerId { get; set; }
        [Required]
        public DateTime Uploadet { get; set; }
        [Required]
        public string Beskrivelse { get; set; }

        public virtual Bruger Bruger { get; set; }
        public virtual Fag Fag { get; set; }
    }
}
