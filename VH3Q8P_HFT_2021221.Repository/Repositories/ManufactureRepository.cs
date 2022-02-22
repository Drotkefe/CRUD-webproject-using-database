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
    public class ManufactureRepository : RepositoryBase<Manufacture, int>, IManufactureRepository
    {
        public ManufactureRepository(BikePurchaseHistoryDbContext context) : base(context)
        {
        }

        public void Delete(Manufacture entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public override Manufacture Read(int id)
        {
            return ReadAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
