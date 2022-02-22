using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VH3Q8P_HFT_2021221.Models.Models
{
    public class AmountOfBikesModel
    {
        public string RiderName { get; set; }
        public int Amount { get; set; }
        public override bool Equals(object obj)
        {
            var other = obj as AmountOfBikesModel;
            return other.RiderName == RiderName && other.Amount == Amount;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
