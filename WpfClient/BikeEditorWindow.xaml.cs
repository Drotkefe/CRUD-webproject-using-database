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
using System.Windows.Shapes;
using VH3Q8P_SG1_21_22_2.WpfClient.Models;
using VH3Q8P_SG1_21_22_2.WpfClient.ViewModels;

namespace VH3Q8P_SG1_21_22_2.WpfClient
{
    /// <summary>
    /// Interaction logic for BikeEditorWindow.xaml
    /// </summary>
    public partial class BikeEditorWindow : Window
    {
        public BikeModel Bike { get; set; }
        bool enableEdit;

        public BikeEditorWindow(BikeModel bike = null, bool enableEdit = true)
        {
            InitializeComponent();
            Bike = bike == null
                ? new BikeModel()
                : new BikeModel(bike);

            this.enableEdit = enableEdit;
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            if (enableEdit)
            {
                DialogResult = true;
            }
            else
            {
                Close();
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            if (enableEdit)
            {
                DialogResult = false;
            }
            else
            {
                Close();
            }
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            var vm = (BikeEditorVM)Resources["VM"];
            vm.CurrentBike = Bike;
            vm.EditEnabled = enableEdit;
        }
    }
}
