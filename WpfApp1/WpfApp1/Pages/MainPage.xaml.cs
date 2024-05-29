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
using VariablePartLibrary.Models;
using VariablePartLibrary.Services;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DGPlant.ItemsSource = DBService.Instance.GetModelData<Plant>().ToList();
            CBType.ItemsSource = DBService.Instance.GetModelData<PlantType>().ToList();
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void CBType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void DGPlant_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedPlant = DGPlant.SelectedItem as Plant;
            if (selectedPlant != null)
            { 
                NavigationService.Navigate(new PlantPage(selectedPlant));
            }
        }

        private void Refresh()
        {
            string searchText = TBSearch.Text.ToLower();
            var selectedType = CBType.SelectedItem as PlantType;

            var plants = DBService.Instance.GetModelData<Plant>().ToList();
            if (string.IsNullOrEmpty(searchText) == false)
            {
                plants = plants.Where(x => x.Name.ToLower().Contains(searchText)).ToList();
            }

            if (selectedType != null)
            {
                plants = plants.Where(x => x.PlantTypeId == selectedType.Id).ToList();
            }

            DGPlant.ItemsSource = plants.ToList();
        }
    }
}
