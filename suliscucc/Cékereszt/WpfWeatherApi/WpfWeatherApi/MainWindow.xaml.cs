using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json.Linq;

namespace WpfWeatherApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JObject idojarasAdat;
        string apikey = "cee47ae14c4e2b23dd70220929479c28";
        public MainWindow()
        {
            InitializeComponent();
        }

        public Label WLabel(string adat)
        {
            Label label = new Label();
            label.FontSize = 20;
            label.Content = adat;

            return label;
        }

        public JObject GetIdojarasAdat(string telepules)
        {
            JObject wdata = JObject.Parse(new WebClient().DownloadString($"http://api.openweathermap.org/data/2.5/weather?q={telepules}&appid={apikey}&units=metric"));

            return wdata;
        }

        private void buttonLeker_Click(object sender, RoutedEventArgs e)
        {
            dataStackpanel.Children.Clear();
            if (textboxVaros.Text.Length>2)
            {
                try
                {
                    idojarasAdat = GetIdojarasAdat(textboxVaros.Text);
                    dataStackpanel.Children.Add(WLabel($"Helyiség:{Convert.ToString(idojarasAdat["name"])}"));
                    dataStackpanel.Children.Add(WLabel($"Hőmérséklet:{Convert.ToString(idojarasAdat["main"]["temp"])}"));
                    dataStackpanel.Children.Add(WLabel($"Hőérzet:{Convert.ToString(idojarasAdat["main"]["feels_like"])}"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);                    
                }
                


            }
        }
    }
}
