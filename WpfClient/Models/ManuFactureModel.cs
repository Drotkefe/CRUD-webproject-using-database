namespace VH3Q8P_SG1_21_22_2.WpfClient.Models
{
    public class ManuFactureModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Establishment_year { get; set; }

        public int Income { get; set; }

        public ManuFactureModel()
        {

        }

        public ManuFactureModel(int id, string name, int establishment_year, int income)
        {
            Id = id;
            Name = name;
            Establishment_year = establishment_year;
            Income = income;
        }
    }
}
