using System;
using System.Collections.Generic;

namespace NillertronNotes.Models
{
    public partial class LoginCookie
    {
        public int Id { get; set; }
        public string Cookie { get; set; }
        public int BrugerId { get; set; }
        public DateTime Expire { get; set; }
        public byte Aktiv { get; set; }
    }
}
