using CommonServiceLocator;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using VH3Q8P_HFT_2021221.Models.BL.Interfaces;
using VH3Q8P_SG1_21_22_2.WpfClient;
using VH3Q8P_SG1_21_22_2.WpfClient.BL.Implementation;
using VH3Q8P_SG1_21_22_2.WpfClient.Infrastructure;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIocAsServiceLocator.Instance);
            SimpleIocAsServiceLocator.Instance.Register<IBikeEditorService, BikeEditorViaWindowService>();
            SimpleIocAsServiceLocator.Instance.Register<IBikeDisplayService, BikeDisplayService>();
            SimpleIocAsServiceLocator.Instance.Register<IBikeHandlerService, BikeHandlerService>();
            SimpleIocAsServiceLocator.Instance.Register(() => Messenger.Default);
        }
    }
}
