using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace WpfNotepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Boolean modositva = false;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void megnyitas_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "szöveg (*.txt)|*.txt|csv (*.csv)|*.csv|minden fájl|*.*";
            if (dialog.ShowDialog()==true)
            {
                try
                {
                    var inputSzoveg = File.ReadAllText(dialog.FileName, Encoding.Default);
                    szoveg.Text = inputSzoveg;
                    this.Title = dialog.FileName;
                    modositva = false;
                    
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void kilepes_Click(object sender, RoutedEventArgs e)
        {
            if (modositva)
            {
                var valasz = MessageBox.Show("A szöveg nincs mentve, menti?", "Figyelem!", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (valasz==MessageBoxResult.OK)
                {
                    MentesMaskent();
                    
                } 
               
               
            }

            Environment.Exit(0);



        }

        private void MentesMaskent_Click(object sender, RoutedEventArgs e)
        {
            MentesMaskent();

        }

        private void MentesMaskent()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "szöveg (*.txt)|*.txt|csv (*.csv)|*.csv|minden fájl|*.*";
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    File.WriteAllText(dialog.FileName, szoveg.Text, Encoding.Default);
                    this.Title = dialog.FileName;
                    modositva = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Mentes_Click(object sender,RoutedEventArgs e)
        {
            if (this.Title!="Notepad")
            {
                File.WriteAllText(this.Title, szoveg.Text, Encoding.Default);
                modositva = false;
            } else
            {
                MentesMaskent();
            }
        }
        private void About_Click(object sender,RoutedEventArgs e)
        {
            About aboutWin = new About();
            aboutWin.ShowDialog();
        }

        private void szoveg_TextChanged(object sender, TextChangedEventArgs e)
        {
            modositva = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (modositva)
            {
                var valasz = MessageBox.Show("A szöveg nincs mentve, menti?", "Figyelem!", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (valasz == MessageBoxResult.OK)
                {
                    MentesMaskent();

                }
                
            }
        }

        private void szoveg_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (szoveg.SelectedText.Length>0)
            {
                menuitemKivagas.IsEnabled = true;
                menuitemMasolas.IsEnabled = true;
            }

            if (szoveg.SelectedText.Length<1)
            {
                menuitemKivagas.IsEnabled = false;
                menuitemMasolas.IsEnabled = false;
            }
        }

        private void Masolas_Click(object sender,RoutedEventArgs e)
        {
            if (szoveg.SelectedText.Length > 0)
            {
                Clipboard.SetText(szoveg.SelectedText);
                menuitemBeillesztes.IsEnabled = true;
            }
        }

        private void Kivagas_Click(object sender,RoutedEventArgs e)
        {
            if (szoveg.SelectedText.Length > 0)
            {
                Clipboard.SetText(szoveg.SelectedText);
                //Hogyan is?
                szoveg.Text = szoveg.Text.Remove(szoveg.CaretIndex, szoveg.SelectedText.Length);
                menuitemBeillesztes.IsEnabled = true;
            }
        }

        private void Beillesztes_Click(object sender,RoutedEventArgs e)
        {
            var pasteText = Clipboard.GetText();
            szoveg.Text = szoveg.Text.Insert(szoveg.CaretIndex, pasteText);
        }
    }
}
