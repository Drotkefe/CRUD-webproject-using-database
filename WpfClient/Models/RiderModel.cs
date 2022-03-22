using GalaSoft.MvvmLight;

namespace VH3Q8P_SG1_21_22_2.WpfClient.Models
{
    public class RiderModel : ObservableObject
    {
        public int id { get; set; }

        public string name { get; set; }

        public int age { get; set; }

        public RiderModel()
        {

        }

        public RiderModel(int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }
    }
}
