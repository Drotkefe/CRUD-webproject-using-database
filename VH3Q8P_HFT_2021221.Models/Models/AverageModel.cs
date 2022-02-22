using System;

namespace VH3Q8P_HFT_2021221.Models.Models
{
    public class AverageModel
    {
        public string ManufactureName { get; set; }
        public double Avarage { get; set; }
        public override bool Equals(object obj)
        {
            var other = obj as AverageModel;
            return other.ManufactureName == ManufactureName && other.Avarage == Avarage;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
