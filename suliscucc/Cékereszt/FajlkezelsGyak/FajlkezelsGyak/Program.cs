using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FajlkezelsGyak
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Ber> berek = new List<Ber>();

            try
            {
                var sorok = File.ReadAllLines("berek2020.txt", Encoding.UTF8);

                for (int i = 1; i < sorok.Length; i++)
                {
                    berek.Add(new Ber(sorok[i]));
                }

                Console.WriteLine($"Feldolgozás kész! Adatok száma:{berek.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //foreach (var i in berek)
            //{
            //    Console.WriteLine($"{i.Nev},{i.Reszleg},{i.Belepes},{i.Bere}");
            //}

            var nok = berek.FindAll(x => x.Nem == "nő");
            Lista(nok);
            //Férfiak lekérdezése megjelenítése
            Console.WriteLine("---------------------------------");
            var ferfiak = berek.FindAll(x => x.Nem == "férfi");

            Lista(ferfiak);

            var fizetesek = berek.FindAll(x=>x.Bere>=180000 && x.Bere<=200000);
            Console.WriteLine("---------------------------------");
            Lista(fizetesek);

            Console.ReadKey();
        }

        private static void Lista(List<Ber> adatok)
        {
            foreach (var i in adatok)
            {
                Console.WriteLine($"{i.Nev},{i.Reszleg},{i.Belepes},{i.Bere}");
            }
        }
    }
}
