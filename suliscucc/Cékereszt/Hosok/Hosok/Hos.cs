using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosok
{
    public abstract class Hos
    {

        public string Nev { get; set; }
        public int Eletero { get; set; }
        public int Sebzes { get; set; }

        protected Hos(string nev, int eletero, int sebzes)
        {
            Nev = nev;
            Eletero = eletero;
            Sebzes = sebzes;
        }

       

       
    }
}
