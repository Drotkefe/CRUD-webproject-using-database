using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH3Q8P_HFT_2021221.Models.Entities;

namespace VH3Q8P_HFT_2021221.Logic.Interfaces
{
    public interface IRiderLogic
    {
        IList<Rider> ReadAll();
        Rider Read(int id);
        Rider Create(Rider entitiy);
        Rider Update(Rider entity);
        void Delete(int id);
    }
}
