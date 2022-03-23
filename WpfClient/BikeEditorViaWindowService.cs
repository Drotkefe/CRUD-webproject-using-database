using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH3Q8P_HFT_2021221.Models.BL.Interfaces;
using VH3Q8P_SG1_21_22_2.WpfClient.Models;

namespace VH3Q8P_SG1_21_22_2.WpfClient
{
    public class BikeEditorViaWindowService: IBikeEditorService
    {
        public BikeModel EditBike(BikeModel bike)
        {
            var window = new BikeEditorWindow(bike);

            if (window.ShowDialog() == true)
            {
                return window.Bike;
            }

            return null;
        }
    }
}
