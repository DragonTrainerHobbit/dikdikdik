using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosok
{
    public class Ijasz:Hos,IIjaz
    {
        public int Pontossag { get; set; }
        public Ijasz(int pontossag, string nev, int eletero, int sebzes):base(nev,eletero,sebzes)
        {
            Pontossag = pontossag;
        }

        public void Ijaz()
        {
            Console.WriteLine("Az íjász lő");
        }
    }
}
