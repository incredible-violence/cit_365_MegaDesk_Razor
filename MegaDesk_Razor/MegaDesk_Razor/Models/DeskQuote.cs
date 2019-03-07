using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDesk_Razor.Models
{
    public class DeskQuote
    {
        public int ID { get; set; }
        public int DeskID { get; set; }

        public string CustomerName { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        public int RushDays { get; set; }

        public int QuoteAmount { get; set; }
    }
}
