using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosok
{
    class Program
    {
        static void Main(string[] args)
        {
            Varazslo varazslo = new Varazslo(120,"Mayhem",100,26);
            Console.WriteLine(varazslo.ToString());

            varazslo.Varazsol();
            

            Console.ReadKey();
        }
    }
}
