using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdojarasV
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IdojarasAdat> idojarasadatok = new List<IdojarasAdat>();
            try
            {
                var sorok = File.ReadAllLines("idojaras.csv", Encoding.Default);
                for (int i = 1; i < sorok.Length; i++)
                {
                    idojarasadatok.Add(new IdojarasAdat(sorok[i]));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

            Console.WriteLine($"Adatsorok száma:{idojarasadatok.Count}");

            //Mekkora a vizsgált időszak az évek tekintetében?
            var minEv = idojarasadatok.Min(x => x.Ev);
            var maxEv = idojarasadatok.Max(x => x.Ev);

            Console.WriteLine($"Első év:{minEv}, utolsó év:{maxEv}");
            //Mekkora a vizsgált időszak átlaghőmérséklete? 
            var atlagHo = idojarasadatok.Average(x => x.Homerseklet);
            Console.WriteLine($"Az időszak átlaghőmérséklete:{atlagHo:0.0}");

            //Kérjünk be egy évet,hónapot,napot
            Console.WriteLine("Adjon meg egy dátumot! (yyyy.mm.dd)");
            var datum = Console.ReadLine();
            var datumAdatok = datum.Split('.');


            while (datumAdatok.Length != 3)
            {
                Console.WriteLine("Hibás dátumformátum!");
                datum = Console.ReadLine();
                datumAdatok = datum.Split('.');
            }
           
            
                var beEv = Convert.ToInt32(datumAdatok[0]);
                var beHonap = Convert.ToInt32(datumAdatok[1]);
                var beNap = Convert.ToInt32(datumAdatok[2]);

                if (idojarasadatok.Any(x=>x.Ev==beEv && x.Honap==beHonap && x.Nap==beNap))
                {
                    var napAdatai = idojarasadatok.FindAll(x => x.Ev == beEv && x.Honap == beHonap && x.Nap == beNap);
                    Console.WriteLine($"A {beEv}.{beHonap}.{beNap} nap átlaghőmérséklete:{napAdatai.Average(x=>x.Homerseklet):0.0}");
                } else
                {
                    Console.WriteLine("Nincs ilyen nap!");
                }


            //Melyik volt a legmelegebb nap?

            var maxHomerseklet = idojarasadatok.Max(x => x.Homerseklet);
            Console.WriteLine($"A legmagasabb hőmérséklet:{maxHomerseklet}");

            var maxHoNapok = idojarasadatok.FindAll(x => x.Homerseklet == maxHomerseklet);

            foreach (var i in maxHoNapok)
            {
                Console.WriteLine($"{i.Ev}.{i.Honap}.{i.Nap} {i.Ora} óra");
            }

            //Jelenítsük meg az egyes évek átlaghőmérsékletét

            var stat = idojarasadatok.ToLookup(x => x.Ev).OrderBy(x=>x.Key);

            foreach (var i in stat)
            {
                Console.WriteLine($"{i.Key} - {i.Average(x=>x.Homerseklet):0.0}");
            }

            var statEvHo = idojarasadatok.ToLookup(x=>new {x.Ev,x.Honap}).OrderByDescending(x=>x.Key.Ev).ThenBy(x=>x.Key.Honap);

            foreach (var i in statEvHo)
            {
                Console.WriteLine($"{i.Key.Ev}.{i.Key.Honap} - {i.Average(x=>x.Homerseklet)}");
            }

            try
            {
                FileStream fajl = new FileStream("atlagho.txt", FileMode.Create);
                StreamWriter writer = new StreamWriter(fajl, Encoding.Default);
                writer.WriteLine($"Ev;Honap;Atlaghomerseklet");
                foreach (var i in statEvHo)
                    {
                        writer.WriteLine($"{i.Key.Ev};{i.Key.Honap};{i.Average(x => x.Homerseklet)}");
                    }

                writer.Close();

                    //using (StreamWriter writer = new StreamWriter(fajl, Encoding.Default))
                    //{
                    //    writer.WriteLine($"Ev;Honap;Atlaghomerseklet");
                    //    foreach (var i in statEvHo)
                    //    {
                    //        writer.WriteLine($"{i.Key.Ev};{i.Key.Honap};{i.Average(x => x.Homerseklet)}");
                    //    }

                    //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

            Console.ReadKey();
        }
    }
}
