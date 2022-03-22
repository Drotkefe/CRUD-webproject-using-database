using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VH3Q8P_SG1_21_22_2.WpfClient.Models
{
    public class BikeModel:ObservableObject
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        private string model_Name;

        public string Model_name
        {
            get { return model_Name; }
            set { Set(ref model_Name , value); }
        }

        private int price;

        public int Price
        {
            get { return price; }
            set { Set(ref price , value); }
        }

        private int brandId;

        public int BrandID
        {
            get { return brandId; }
            set { Set(ref brandId ,value); }
        }

        private int riderId;

        public int RiderID
        {
            get { return riderId; }
            set { Set(ref riderId, value); }
        }

        public BikeModel()
        {

        }

        public BikeModel(int id, string model_Name, int price, int brandId, int riderId)
        {
            this.id = id;
            this.model_Name = model_Name;
            this.price = price;
            this.brandId = brandId;
            this.riderId = riderId;
        }

        public BikeModel(BikeModel other)
        {
            id = other.id;
            model_Name = other.model_Name;
            price = other.price;
            brandId = other.brandId;
            riderId = other.riderId;
        }
    }
}
