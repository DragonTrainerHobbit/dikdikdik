using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
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
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using Microsoft.Win32;

namespace WpfQRCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
          
        }

        private void buttonKodgeneralas_Click(object sender, RoutedEventArgs e)
        {
           

            try
            {
                QRCodeEncoder encoder = new QRCodeEncoder();
                QRCodeDecoder decoder = new QRCodeDecoder();
                

                Bitmap qrBitmap = encoder.Encode(textboxQrtext.Text);
                qrBitmap.Save("qrminta.png");
                encoder.CharacterSet = "UTF-8";
                using (MemoryStream ms = new MemoryStream())
                {
                    qrBitmap.Save(ms, ImageFormat.Png);
                    ms.Position = 0;
                    BitmapImage qrBitmapImage = new BitmapImage();
                    qrBitmapImage.BeginInit();
                    qrBitmapImage.StreamSource = ms;
                    qrBitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    qrBitmapImage.EndInit();
                    imageQrcode.Source = qrBitmapImage;

                }
                var dekodolt = decoder.Decode(new QRCodeBitmapImage(qrBitmap));
                Debug.WriteLine(dekodolt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);                
            }

            
        }

        private void buttonOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog()==true)
            {
                BitmapImage loadImage = new BitmapImage(new Uri(dialog.FileName));
                imageDecode.Source = loadImage;

                QRCodeDecoder decoder = new QRCodeDecoder();

                using (MemoryStream ms=new MemoryStream())
                {
                    BitmapEncoder bitmapEncoder = new PngBitmapEncoder();
                    bitmapEncoder.Frames.Add(BitmapFrame.Create(loadImage));
                    bitmapEncoder.Save(ms);
                    Bitmap dekodolni = new Bitmap(ms);
                    var qrtext = decoder.Decode(new QRCodeBitmapImage(dekodolni));
                    textboxDecodeText.Text = qrtext;
                }



            }
        }
    }
}
