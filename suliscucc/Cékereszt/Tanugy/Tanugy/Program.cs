using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanugy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tanulo> tanulok = new List<Tanulo>();
            List<Tanar> tanarok = new List<Tanar>();

            tanulok.Add(new Tanulo("Kiss Ubul", 2003));
            tanulok.Add(new Tanulo("Vozár Ella", 2004));

            tanarok.Add(new Tanar("Kovács Győző", "matematika"));
            tanarok.Add(new Tanar("Nagy Elek", "irodalom"));
            tanarok.Add(new Tanar("Füzesi Béla", "testnevelés"));

            SuliOsztaly osztaly9a = new SuliOsztaly(tanulok,tanarok,"9a");

            osztaly9a.TanuloLista();
            osztaly9a.TanarLista();
            osztaly9a.SetOsztalyfonok("nAgy elEk", "irodalom");

            Console.WriteLine(osztaly9a.GetOsztalyfonok());
            osztaly9a.SetOSztalynev("10a");
            Console.WriteLine(osztaly9a.ToString());

            Console.ReadKey();
        }
    }
}
