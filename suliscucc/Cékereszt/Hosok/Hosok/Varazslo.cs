using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosok
{
    public class Varazslo:Hos,IVarazsol
    {

        public int Varazsero { get; set; }
        public Varazslo(int varazsero, string nev, int eletero, int sebzes):base(nev,eletero,sebzes)
        {
            Varazsero = varazsero;
        }

        public override string ToString()
        {
            return $"{Varazsero},{Nev},{Eletero},{Sebzes}";
        }

        public void Varazsol()
        {
            Console.WriteLine("Varázslás!");
        }
    }
}
