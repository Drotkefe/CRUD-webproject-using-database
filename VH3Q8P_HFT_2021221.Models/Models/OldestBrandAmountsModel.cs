using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VH3Q8P_HFT_2021221.Models.Models
{
    public class OldestBrandAmountsModel
    {
        public string ManufactureName { get; set; }
        public int Amount { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as OldestBrandAmountsModel;
            return other.ManufactureName == ManufactureName && other.Amount == Amount;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
