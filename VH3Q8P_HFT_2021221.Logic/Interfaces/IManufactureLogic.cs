using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH3Q8P_HFT_2021221.Models.Entities;

namespace VH3Q8P_HFT_2021221.Logic.Interfaces
{
    public interface IManufactureLogic
    {
        IList<Manufacture> ReadAll();
        Manufacture Read(int id);
        Manufacture Create(Manufacture entitiy);
        Manufacture Update(Manufacture entity);
        void Delete(int id);
    }
}
