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
        public int Scor { get; set; }
    }
}
