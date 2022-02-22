using System.Collections.Generic;
using VH3Q8P_HFT_2021221.Models.Entities;
using VH3Q8P_HFT_2021221.Models.Models;

namespace VH3Q8P_HFT_2021221.Logic.Interfaces
{
    public interface IBikeLogic
    {
        IList<Bike> ReadAll();
        Bike Read(int id);
        Bike Create(Bike entitiy);
        Bike Update(Bike entity);
        void Delete(int id);
        //Non-Crud methods
        IEnumerable<AverageModel> GetManufactureAvarages();
        IEnumerable<MostBikeModel> GetMostBikesUser();
        IEnumerable<AmountOfBikesModel> GetAmounts();
        IEnumerable<OldestBrandAmountsModel> GetOldestManufactureAmounts();
        IEnumerable<PricePerPersonModel> GetPricePerPeople();
    }
}
