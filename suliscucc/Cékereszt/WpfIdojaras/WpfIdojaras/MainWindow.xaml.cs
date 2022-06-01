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

namespace WpfIdojaras
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Adapter adapter;
        public MainWindow()
        {
            InitializeComponent();
            adapter = new Adapter("Data Source=d:/rud/idojarasadatok.db;Version=3");
            adatok.ItemsSource = adapter.GetData().DefaultView;
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                adapter.UpdateData();
                adatok.Items.Refresh();
                MessageBox.Show("Ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
