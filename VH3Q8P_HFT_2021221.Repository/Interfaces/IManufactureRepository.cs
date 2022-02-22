using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH3Q8P_HFT_2021221.Models.Entities;

namespace VH3Q8P_HFT_2021221.Repository.Interfaces
{
    public interface IManufactureRepository : IRepositoryBase<Manufacture,int>
    {
        void Delete(Manufacture entity);
    }
}
