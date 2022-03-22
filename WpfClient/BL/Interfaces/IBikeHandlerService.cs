using System.Collections.Generic;
using VH3Q8P_SG1_21_22_2.WpfClient.Models;

namespace VH3Q8P_HFT_2021221.Models.BL.Interfaces
{
    public interface IBikeHandlerService
    {
        void AddBike(IList<BikeModel> collection);
        void ModifyBike(IList<BikeModel> collection, BikeModel bike);
        void DeleteBike(IList<BikeModel> collection, BikeModel bike);
        void ViewCar(BikeModel bike);

        IList<BikeModel> GetAll();

        IList<BikeModel> GetAllBrands();
    }
}
