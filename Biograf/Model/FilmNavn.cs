using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biograf.Model
{
    public class FilmNavn
    {
        public string filmNavn { get; set; }
        public double pris { get; set; }
        public DateTime releaseDato { get; set; }
        public string description { get; set; }
        public bool treDtoD { get; set; }
        public string sal { get; set; }
        public double rating { get; set; }


        public override string ToString()
        {
            return "Titel: " + filmNavn + ", " + "Pris: " + pris + ", " + "I biografen: " + releaseDato + ", " + "Beskrivelse: " + description + ", " + sal + ", " + "Rating: " + rating;
        }

    }
}
