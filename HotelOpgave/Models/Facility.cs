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
        public int Fac_Id { get; set; }        
        public string? Name { get; set; }
        public override string ToString()
        {
            return $"Fac_Id: {Fac_Id} | Name: {Name}";
        }
    }
}
