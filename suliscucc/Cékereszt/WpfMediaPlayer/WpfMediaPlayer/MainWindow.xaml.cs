using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfMediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Medialista mediaLista { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            mediaPlayer.LoadedBehavior = MediaState.Manual;
            mediaLista = new Medialista();
            listboxMedialist.DataContext = mediaLista;
        }

        private void buttonOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            if (dialog.ShowDialog()==true)
            {

                if (dialog.FileNames.Length>0)
                {
                    mediaLista.SetMediaLista(dialog.FileNames, '\\');
                    listboxMedialist.SelectedIndex = 0;
                }

            }
        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void buttonPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void listboxMedialist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mediaelem elem = (Mediaelem)listboxMedialist.SelectedItem;
            mediaPlayer.Source = new Uri(elem.TeljesUtvonal);
            this.Title = elem.TeljesUtvonal;
        }
    }
}
