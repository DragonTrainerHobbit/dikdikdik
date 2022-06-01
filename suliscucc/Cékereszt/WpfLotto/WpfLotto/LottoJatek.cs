using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfLotto
{
    public class LottoJatek
    {
        private MainWindow mainWindow;
        private List<int> tippek;
        private List<int> nyeroSzamok;
        private int hanySzam;
        private int sorSzam;
        private int oszlopSzam;
        private int szamlalo;
        public int Talalatok { get { return talalatok; }  }
        private int talalatok;
        Random rnd;

        public LottoJatek(MainWindow mainwindow,int hanyszam,int sorszam,int oszlopszam)
        {
            mainWindow = mainwindow;
            tippek = new List<int>();
            nyeroSzamok = new List<int>();
            hanySzam = hanyszam;
            sorSzam = sorszam;
            oszlopSzam = oszlopszam;
                       
            rnd = new Random();
            mainWindow.buttonSorsolas.Click += SorsolasClick;
            mainWindow.buttonUj.Click += UjJatek;
            
            
        }

        private void UjJatek(object sender,EventArgs e)
        {
                     
            Gombok();
            tippek.Clear();
            nyeroSzamok.Clear();
            mainWindow.textBlockTalat.Text = "";
            szamlalo = 1;
            talalatok = 0;
        }

        private void Gombok()
        {
            Grid gridSzamok = new Grid();

            for (int i = 0; i < sorSzam; i++)
            {
                RowDefinition sorDef = new RowDefinition();
                gridSzamok.RowDefinitions.Add(sorDef);
            }

            for (int i = 0; i < oszlopSzam; i++)
            {
                ColumnDefinition oszlopDef = new ColumnDefinition();
                gridSzamok.ColumnDefinitions.Add(oszlopDef);
            }

            var gombszam = 1;
            for (int i = 0; i < sorSzam; i++)
            {
                for (int j = 0; j < oszlopSzam; j++)
                {
                    Button gomb = new Button();
                    gomb.Content = gombszam;
                    gomb.Margin = new System.Windows.Thickness(5);
                    gomb.Click += GombClick;
                    gombszam++;

                    gridSzamok.Children.Add(gomb);
                    Grid.SetRow(gomb, i);
                    Grid.SetColumn(gomb,j);
                }

            }

            //itt kéne megtalálni a gridMain-t valahogy
            mainWindow.gridGombok.Children.Add(gridSzamok);
        }

        private void GombClick(object sender,EventArgs e)
        {
            Button gomb = (Button)sender;
            var gombSzam= Convert.ToInt32(gomb.Content);

            if (szamlalo<=hanySzam && !tippek.Contains(gombSzam))
            {
                tippek.Add(gombSzam);
                Debug.WriteLine(gombSzam);
               
                gomb.Foreground = Brushes.Red;
                gomb.Background = Brushes.AliceBlue;

                szamlalo++;
            }
            if (szamlalo>hanySzam)
            {
                mainWindow.buttonSorsolas.IsEnabled = true;
                mainWindow.buttonUj.IsEnabled = false;
            }
            
        }

        private void SorsolasClick(object sender,EventArgs e)
        {
            Sorsolas();
            GetTalalat();
            Kiemeles();
            mainWindow.textBlockTalat.Text = talalatok.ToString();
            mainWindow.buttonSorsolas.IsEnabled = false;
            mainWindow.buttonUj.IsEnabled = true;

        }

        private void Kiemeles()
        {
            foreach (Grid gr in mainWindow.gridGombok.Children)
            {
                foreach (Button button in gr.Children)
                {
                    if (nyeroSzamok.Contains(Convert.ToInt32(button.Content)))
                    {
                        button.Foreground = Brushes.Red;
                        button.Background = Brushes.Green;
                    }

                    if (nyeroSzamok.Contains(Convert.ToInt32(button.Content)) && tippek.Contains(Convert.ToInt32(button.Content)))
                    {
                        button.Foreground = Brushes.Red;
                        button.Background = Brushes.Gold;
                    }


                }
            }
        }

        private void Sorsolas()
        {
            for (int i = 0; i < hanySzam; i++)
            {
                var nyeroszam = rnd.Next(1, (sorSzam * oszlopSzam) + 1);
                while (nyeroSzamok.Contains(nyeroszam))
                {
                    nyeroszam = rnd.Next(1, (sorSzam * oszlopSzam) + 1);
                }
                nyeroSzamok.Add(nyeroszam);
            }

        }

        private void GetTalalat()
        {
            for (int i = 0; i < tippek.Count; i++)
            {
                if (nyeroSzamok.Contains(tippek[i]))
                {
                    talalatok++;
                }
            }
        }
    }
}
