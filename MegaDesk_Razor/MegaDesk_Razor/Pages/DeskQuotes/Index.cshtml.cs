using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk_Razor.Models;

namespace MegaDesk_Razor.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDesk_Razor.Models.MegaDesk_RazorContext _context;

        public IndexModel(MegaDesk_Razor.Models.MegaDesk_RazorContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; }

        public async Task OnGetAsync()
        {
            DeskQuote = await _context.DeskQuote.ToListAsync();
        }
    }
}
