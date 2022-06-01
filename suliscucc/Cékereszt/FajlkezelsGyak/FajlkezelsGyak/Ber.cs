using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FajlkezelsGyak
{
    public class Ber
    {
        public string Nev { get; set; }
        public string Nem { get; set; }
        public string Reszleg { get; set; }
        public int Belepes { get; set; }
        public int Bere { get; set; }

        public Ber(string sor)
        {
            var adatok = sor.Split(';');
            Nev = adatok[0];
            Nem = adatok[1];
            Reszleg = adatok[2];
            Belepes = Convert.ToInt32(adatok[3]);
            Bere = Convert.ToInt32(adatok[4]);

        }
    }
}
