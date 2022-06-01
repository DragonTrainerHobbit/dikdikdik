using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versenyzok
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Versenyzo> versenyzok = new List<Versenyzo>();

            try
            {
                var sorok = File.ReadAllLines("pilotak.csv",Encoding.Default);
                for (int i = 1; i < sorok.Length; i++)
                {
                    versenyzok.Add(new Versenyzo(sorok[i]));
                }

                Console.WriteLine($"Feldolgozás kész! Adatok száma:{versenyzok.Count}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }


            Console.WriteLine($"Az utolsó pilóta:{versenyzok[versenyzok.Count-1].Nev}");
            Console.WriteLine($"Az utolsó pilóta:{versenyzok.Last().Nev}");

            var p19 = versenyzok.FindAll(x=>x.SzuletesiDatum.Year<1901);

            foreach (var i in p19)
            {
                Console.WriteLine($"{i.Nev},{i.SzuletesiDatum.Year}.{i.SzuletesiDatum.Month}.{i.SzuletesiDatum.Day}");
            }

            var vanrajtszam = versenyzok.FindAll(x=>x.Rajtszam>=0);

            Console.WriteLine(vanrajtszam.Find(x=>x.Rajtszam==vanrajtszam.Min(y=>y.Rajtszam)).Nemzetiseg);

            var stat = vanrajtszam.ToLookup(x=>x.Rajtszam);

            var kiir = "";
            foreach (var i in stat)
            {
                if (i.Count()>1)
                {
                    //Console.WriteLine($"{i.Key},{i.Count()}");
                    kiir += i.Key + ",";
                }
                
            }

            Console.WriteLine(kiir.TrimEnd(','));

            Console.ReadKey();
        }
    }
}
