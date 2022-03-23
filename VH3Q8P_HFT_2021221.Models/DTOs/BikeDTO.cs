using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VH3Q8P_HFT_2021221.Models.DTOs
{
    public class BikeDTO
    {
       public int Id { get; set; }
       public string Model_Name { get; set; }
       public int Price { get; set; }
       public bool Fix { get; set; }
       public int BrandId { get; set; }
       public int RiderId { get; set; }
    }
}
