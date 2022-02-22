using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH3Q8P_HFT_2021221.Models.Entities;
using VH3Q8P_HFT_2021221.Repository.Interfaces;
using VH3Q8P_HFT_2021221.Data.DbContexts;

namespace VH3Q8P_HFT_2021221.Repository.Repositories
{
    public class BikeRepository : RepositoryBase<Bike, int>, IBikeRepository
    {
        public BikeRepository(BikePurchaseHistoryDbContext context) : base(context)
        {
        }
        public override Bike Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
