using MessagingToolkit.QRCode.Codec;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VariablePartLibrary.Models;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Interaction logic for PlantPage.xaml
    /// </summary>
    public partial class PlantPage : Page
    {
        Plant contextPlant;
        public PlantPage(Plant plant)
        {
            InitializeComponent();
            contextPlant = plant;
            DataContext = contextPlant;
            
            if (plant.PlantTypeId == 1)
            {
                MainGrid.Background = Brushes.Green;
            }

            if (plant.PlantTypeId == 2)
            {
                MainGrid.Background = Brushes.Blue;
            }

            if (plant.PlantTypeId == 3)
            {
                MainGrid.Background = Brushes.Aqua;
            }

            var encoder = new QRCodeEncoder();

            var image = encoder.Encode(plant.Description);

            QrCode.Source = Imaging.CreateBitmapSourceFromHBitmap(image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, null);
        }
    }
}
