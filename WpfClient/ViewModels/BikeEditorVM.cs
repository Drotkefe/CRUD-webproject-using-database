using CommonServiceLocator;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH3Q8P_HFT_2021221.Models.BL.Interfaces;
using VH3Q8P_SG1_21_22_2.WpfClient.Models;

namespace VH3Q8P_SG1_21_22_2.WpfClient.ViewModels
{
    public class BikeEditorVM : ViewModelBase
    {
        private BikeModel currentBike;

        public BikeModel CurrentBike
        {
            get { return currentBike; }
            set
            {
                Set(ref currentBike, value);
                SelectedBrand = AvailableBrands?.SingleOrDefault(x => x.Id == currentBike.BrandID);
                SelectedRider = AvailableRiders?.SingleOrDefault(x => x.id == currentBike.RiderID);
            }
        }

        private ManuFactureModel brandModel;

        public ManuFactureModel SelectedBrand
        {
            get { return brandModel; }
            set
            {
                Set(ref brandModel, value);
                currentBike.BrandID = brandModel?.Id ?? 0;
            }
        }

        private RiderModel riderModel;

        public RiderModel SelectedRider
        {
            get { return riderModel; }
            set
            {
                Set(ref riderModel, value);
                currentBike.RiderID = riderModel?.id ?? 0;
            }
        }


        public IList<ManuFactureModel> AvailableBrands { get; private set; }
        public IList<RiderModel> AvailableRiders { get; private set; }

        private bool editEnabled;

        public bool EditEnabled
        {
            get { return editEnabled; }
            set
            {
                Set(ref editEnabled, value);
                RaisePropertyChanged(nameof(CancelButtonVisibility));
            }
        }

        public System.Windows.Visibility CancelButtonVisibility => EditEnabled ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;

        public BikeEditorVM(IBikeHandlerService bikeHandlerService)
        {
            CurrentBike = new BikeModel();

            if (IsInDesignModeStatic)
            {
                AvailableBrands = new List<ManuFactureModel>()
                {
                    new ManuFactureModel(1,"Alma",1855,20),
                    new ManuFactureModel(2,"Répa",2015,520),
                    new ManuFactureModel(3,"Körte",1945,1420),

                };
                AvailableRiders = new List<RiderModel>()
                {
                    new RiderModel(1,"Laci",28),
                    new RiderModel(2,"Peti",42),
                    new RiderModel(3,"Sanyi",18),
                };

                SelectedBrand = AvailableBrands[1]; // Should sets the brandId too
                SelectedRider = AvailableRiders[2];
                CurrentBike.Model_name = "Kis bicikli";
                CurrentBike.Price = 1750;
               
            }
            else
            {
                AvailableBrands = bikeHandlerService.GetAllBrands();
                AvailableRiders = bikeHandlerService.GetAllRiders();
            }
        }

        public BikeEditorVM() : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IBikeHandlerService>())
        {
        }
    }
}
