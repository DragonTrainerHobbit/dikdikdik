using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versenyzok
{
    public class Versenyzo
    {
        public string Nev { get; set; }
        public DateTime SzuletesiDatum { get; set; }
        public string Nemzetiseg { get; set; }
        public int Rajtszam { get; set; }

        public Versenyzo(string sor)
        {
            var adatok = sor.Split(';');
            Nev = adatok[0];
            SzuletesiDatum = Convert.ToDateTime(adatok[1]);
            Nemzetiseg = adatok[2];
            
            if (adatok[3].Length>0)
            {
                Rajtszam = Convert.ToInt32(adatok[3]);

            } else
            {
                Rajtszam = -111;
            }
            
        }
    }
}
