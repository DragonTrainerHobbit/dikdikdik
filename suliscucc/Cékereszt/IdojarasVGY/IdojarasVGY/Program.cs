using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdojarasVGY
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IdojarasAdat> idojarasAdatok = new List<IdojarasAdat>();
            try
            {
                var sorok = File.ReadAllLines("idojaras.csv", Encoding.Default);
                for (int i = 1; i < sorok.Length; i++)
                {
                    idojarasAdatok.Add(new IdojarasAdat(sorok[i]));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

            Console.WriteLine(idojarasAdatok.Count);

            //2009-ben hány napon volt hidegebb,
            //mint a vizsgált időszak átlaghőmérséklete?

            //2009-ben hány napon volt hidegebb,
            //mint 2009 átlaghőmérséklete?
            var atlagHo = idojarasAdatok.Average(x => x.Homerseklet);
            var atlagHo2009 = idojarasAdatok.FindAll(x => x.Ev == 2009).Average(x=>x.Homerseklet);
            var hidegebbOsszes = idojarasAdatok.FindAll(x => x.Homerseklet < atlagHo && x.Ev==2009).Count/24;
            var hidegebb2009 = idojarasAdatok.FindAll(x => x.Homerseklet < atlagHo2009 && x.Ev == 2009).Count/24;

            Console.WriteLine($"{hidegebbOsszes} napon volt hidegebb, mint az átlaghőmérséklet");
            Console.WriteLine($"{hidegebb2009} napon volt hidegebb, mint 2009 átlaghőmérséklete");

            //Készítsen statisztikát amely megjeleníti 2010 hónapjainak min,max hőmérsékleteit
            var adatok2010 = idojarasAdatok.FindAll(x => x.Ev == 2010);
            var stat = adatok2010.ToLookup(x=>new {x.Ev,x.Honap }).OrderByDescending(x=>x.Key.Ev).ThenBy(x=>x.Key.Honap);

            foreach (var i in stat)
            {
                Console.WriteLine($"{i.Key.Ev}.{i.Key.Honap} - Min:{i.Min(x=>x.Homerseklet):0.0} Max:{i.Max(x => x.Homerseklet):0.0}");
            }

            Console.ReadKey();
        }
    }
}
