using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDesk_Razor.Models
{
    public class DeskQuote
    {
        public int ID { get; set; }
        private string CustomerName { get; set; }
        private DateTime QuoteDate = DateTime.Today;
        private Desk newDesk = new Desk();
        private int RushDays { get; set; }
        private int QuoteAmount { get; set; }
    }
}
