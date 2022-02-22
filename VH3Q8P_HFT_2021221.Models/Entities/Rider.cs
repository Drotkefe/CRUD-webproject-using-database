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
    [Table("Customers")]
    public class Rider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Bike> Bikes { get; set; }


    }
}
