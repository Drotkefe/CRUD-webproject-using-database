using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH3Q8P_HFT_2021221.Data.DbContexts;
using VH3Q8P_HFT_2021221.Models.Entities;
using VH3Q8P_HFT_2021221.Repository.Interfaces;

namespace VH3Q8P_HFT_2021221.Repository.Repositories
{
    public class RiderRepository : RepositoryBase<Rider, int>, IRiderRepository
    {
        public RiderRepository(BikePurchaseHistoryDbContext context) : base(context)
        {
        }

        public override Rider Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
    }



}
