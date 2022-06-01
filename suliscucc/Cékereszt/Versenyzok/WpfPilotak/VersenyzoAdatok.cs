using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versenyzok;

namespace WpfPilotak
{
    public class VersenyzoAdatok
    {
        public List<Versenyzo> Versenyzok { get { return _versenyzok; } }
        private List<Versenyzo> _versenyzok { get; set; }

        public VersenyzoAdatok(string fajl)
        {
            _versenyzok = new List<Versenyzo>();

            var sorok = File.ReadAllLines(fajl,Encoding.Default);

            for (int i = 1; i < sorok.Length; i++)
            {
                _versenyzok.Add(new Versenyzo(sorok[i]));
            }

        }
    }
}
