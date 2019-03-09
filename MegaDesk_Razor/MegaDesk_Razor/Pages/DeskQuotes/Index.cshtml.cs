using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk_Razor.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MegaDesk_Razor.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDesk_Razor.Models.MegaDesk_RazorContext _context;

        public IndexModel(MegaDesk_Razor.Models.MegaDesk_RazorContext context)
        {
            _context = context;
        }

        public PaginatedList<DeskQuote> DeskQuote { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList CustomerName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string QuoteName { get; set; }
        public string QuoteSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string sortOrder, string CurrentFilter, string SearchString, int? pageIndex)
        {
            // Use LINQ to get list of genres.
            CurrentSort = sortOrder;
            QuoteSort = String.IsNullOrEmpty(sortOrder) ? "quote_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (SearchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }

            CurrentFilter = SearchString;

            IQueryable<string> nameQuery = from n in _context.DeskQuote
                                           orderby n.CustomerName
                                           select n.CustomerName;

            var quotes = from n in _context.DeskQuote
                         select n;

            switch (sortOrder)
            {
                case "name_desc":
                    quotes = quotes.OrderByDescending(n => n.CustomerName);
                    break;
                case "Date":
                    quotes = quotes.OrderBy(n => n.OrderDate);
                    break;
                case "date_desc":
                    quotes = quotes.OrderByDescending(n => n.OrderDate);
                    break;
                default:
                    quotes = quotes.OrderBy(n => n.CustomerName);
                    break;
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                quotes = quotes.Where(s => s.CustomerName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(QuoteName))
            {
                quotes = quotes.Where(x => x.CustomerName == QuoteName);
            }
            int pageSize = 5;

            CustomerName = new SelectList(await nameQuery.Distinct().ToListAsync());
            DeskQuote = await PaginatedList<DeskQuote>.CreateAsync(quotes.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
