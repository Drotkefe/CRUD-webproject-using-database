using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VH3Q8P_HFT_2021221.Models.Entities
{
    [Table("Manufactures")]
    public class Manufacture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        public int Establishment_year { get; set; }

        public int Income { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Bike> Bikes { get; set; }

    }
}
