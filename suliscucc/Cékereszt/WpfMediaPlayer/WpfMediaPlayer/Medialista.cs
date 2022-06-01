using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMediaPlayer
{
    public class Medialista
    {
        public ObservableCollection<Mediaelem> Mediaelemek { get; set; }

        public Medialista()
        {
            Mediaelemek = new ObservableCollection<Mediaelem>();
        }

        public void SetMediaLista(string[] fajlok,char elvalaszto)
        {
            foreach (var i in fajlok)
            {
                Mediaelemek.Add(new Mediaelem(i, elvalaszto));
            }
        }
    }
}
