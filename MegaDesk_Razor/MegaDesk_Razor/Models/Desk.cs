using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDesk_Razor.Models
{
    public class Desk
    {
        public int ID { get; set; }

        [Display(Name = "Quote Date")]
        [DataType(DataType.Date)]
        public DateTime LogDate { get; set; }

        [Range(24, 96)]
        [Required]
        public int Width { get; set; }

        [Range(12, 48)]
        [Required]
        public int Length { get; set; }

        public string Material { get; set; }
    }
}