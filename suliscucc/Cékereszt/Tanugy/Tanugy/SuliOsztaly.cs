using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanugy
{
    public class SuliOsztaly
    {
        List<Tanulo> Tanulok { get; set; }
        List<Tanar> Tanarok { get; set; }
        string Osztalynev { get; set; }

        Tanar Osztalyfonok { get; set; }

        public SuliOsztaly(List<Tanulo> tanulok, List<Tanar> tanarok, string osztalynev)
        {
            Tanulok = tanulok;
            Tanarok = tanarok;
            Osztalynev = osztalynev;
        }

        public void TanuloLista()
        {
            foreach (var i in Tanulok)
            {
                Console.WriteLine($"Név:{i.Nev},{i.SzuletesiEv}");
            }
        }

        public void TanarLista()
        {
            foreach (var i in Tanarok)
            {
                Console.WriteLine($"Név:{i.Nev},{i.Szak}");
            }
        }

       public void SetOsztalyfonok(string nev,string szak)
        {
            var osztalyfonok = Tanarok.Find(x=>x.Nev.ToLower()==nev.ToLower() && x.Szak.ToLower()==szak.ToLower());
            if (osztalyfonok!=null)
            {
                Osztalyfonok = osztalyfonok;
                Console.WriteLine($"{nev} beállítva!");
            } else
            {
                Console.WriteLine("Nincs ilyen tanár!");
            }
        }

        public string GetOsztalyfonok()
        {
            return Osztalyfonok.Nev;
        }

        public void SetOSztalynev(string osztalynev)
        {
            Osztalynev = osztalynev;
        }

        public override string ToString()
        {
            return $"Osztály:{Osztalynev},Létszám:{Tanulok.Count}";
        }


    }
}
