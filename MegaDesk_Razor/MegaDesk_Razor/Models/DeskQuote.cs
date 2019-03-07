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
        private string CustomerName { get; set; }

        [DataType(DataType.Date)]
        private DateTime OrderDate { get; set; }

        private Desk newDesk = new Desk();
        private int RushDays { get; set; }
        private int QuoteAmount { get; set; }
    }
}
