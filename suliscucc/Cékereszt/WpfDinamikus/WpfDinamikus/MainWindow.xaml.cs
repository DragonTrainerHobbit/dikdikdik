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

namespace WpfDinamikus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                Button button = new Button();
                button.Content = $"{i + 1}.gomb";
                button.FontSize = 26;
                
                
                button.Width = 150;
                button.Click += GombClick;
                button.Margin = new Thickness(10);
                wrapGombok.Children.Add(button);

            }
        }

        private void GombClick(object sender,RoutedEventArgs e)
        {
            Button button = (Button)sender;
            button.Foreground = Brushes.Red;
            button.Background = Brushes.Green;
            textButtonContent.Text = button.Content.ToString();
            
        }
    }
}
