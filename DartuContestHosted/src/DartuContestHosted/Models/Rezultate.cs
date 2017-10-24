using System;
using System.Collections.Generic;

namespace DartuContestHosted.Models
{
    public partial class Rezultate
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int Clasa { get; set; }
        public string Scoala { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }
    }
}
