using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VH3Q8P_HFT_2021221.Models.Entities
{
    [Table("Bicycles")]
    public class Bike
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Model_Name { get; set; }
        public int Price { get; set; }
        public int BrandId { get; set; }
        public int RiderId { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual Manufacture Manufacture { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual Rider Rider { get; set; }


    }
}
