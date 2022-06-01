using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMediaPlayer
{
    public class Mediaelem
    {
        public string TeljesUtvonal { get; set; }
        public string FajlNev { get; set; }

        public Mediaelem(string teljesutvonal,char elvalaszto)
        {
            TeljesUtvonal = teljesutvonal;
            var e = teljesutvonal.Split(elvalaszto);
            FajlNev = e.Last();
        }
    }
}
