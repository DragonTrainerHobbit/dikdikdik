using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atletika
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Versenyszam> versenyszamok = new List<Versenyszam>();
            try
            {
                var sorok = File.ReadAllLines("atletikaVB2017.csv",Encoding.Default);
                for (int i = 0; i < sorok.Length; i++)
                {
                    versenyszamok.Add(new Versenyszam(sorok[i]));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
                       

            var versenyszamokDb = versenyszamok.ToLookup(x => x.VersenyszamNeve).Count;

            Console.WriteLine($"Sorok:{versenyszamok.Count},{versenyszamokDb}");

            var usa = versenyszamok.FindAll(x => x.Orszag == "Egyesült Államok");
            var usaarany = usa.FindAll(x => x.Helyezes == 1).Count;

            Console.WriteLine($"usa:{(double)usaarany/(double)usa.Count:0.000}");
    


            Console.ReadKey();
        }
    }
}
