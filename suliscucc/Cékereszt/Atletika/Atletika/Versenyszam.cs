using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atletika
{
    public class Versenyszam
    {
        public string VersenyszamNeve { get; set; }
        public string Nem { get; set; }
        public string Orszag { get; set; }
        public string VersenyzoNev { get; set; }
        public string  Eredmeny { get; set; }
        public string Csucs { get; set; }
        public int Helyezes { get; set; }

        public Versenyszam(string sor)
        {
            var e = sor.Split(';');
            VersenyszamNeve = e[0];
            Nem = e[1];
            Orszag = e[2];
            VersenyzoNev = e[3];
            Eredmeny = e[4];
            Csucs = e[5];
            Helyezes = Convert.ToInt32(e[6]);
        }

    }
}
