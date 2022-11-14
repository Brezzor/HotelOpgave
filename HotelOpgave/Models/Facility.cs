using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpgave.Models
{    
    [Table("Facility")]
    public class Facility
    {        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public Facility(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"Id: {Id} | Name: {Name}";
        }
    }
}
