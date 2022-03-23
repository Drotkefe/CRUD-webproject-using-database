using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VH3Q8P_HFT_2021221.Models.BL.Interfaces;
using VH3Q8P_SG1_21_22_2.WpfClient.Models;

namespace WpfClient.ViewModels
{
    public class MainWindowVM: ViewModelBase
    {
        private BikeModel currentBike;

        public BikeModel CurrentBike
        {
            get { return currentBike; }
            set { Set(ref currentBike, value); }
        }

        public ObservableCollection<BikeModel> Bikes { get; private set; }



        public ICommand AddCommand { get; private set; }
        public ICommand ModifyCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand ViewCommand { get; private set; }

        public ICommand LoadCommand { get; private set; }

        readonly IBikeHandlerService bikeHandlerService;

        public MainWindowVM(IBikeHandlerService bikeHandlerService)
        {
            this.bikeHandlerService = bikeHandlerService;
            Bikes = new ObservableCollection<BikeModel>();

            if (IsInDesignMode)
            {
                Bikes.Add(new BikeModel(1, "bicó", 50, 1, 1,true));
                Bikes.Add(new BikeModel(2, "bicóka", 150, 2, 2,false));
            }

            LoadCommand = new RelayCommand(() =>
            {
                var bikes = this.bikeHandlerService.GetAll();
                Bikes.Clear();

                foreach (var bike in bikes)
                {
                    Bikes.Add(bike);
                }
            });

            AddCommand = new RelayCommand(() => this.bikeHandlerService.AddBike(Bikes));
            ModifyCommand = new RelayCommand(() => this.bikeHandlerService.ModifyBike(Bikes, CurrentBike));
            DeleteCommand = new RelayCommand(() => this.bikeHandlerService.DeleteBike(Bikes, CurrentBike));
            ViewCommand = new RelayCommand(() => this.bikeHandlerService.ViewBike(CurrentBike));
        }

        public MainWindowVM() : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IBikeHandlerService>())
        {
        }
    }

}

