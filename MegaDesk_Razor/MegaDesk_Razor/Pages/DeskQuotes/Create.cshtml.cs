using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDesk_Razor.Models;

namespace MegaDesk_Razor.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDesk_Razor.Models.MegaDesk_RazorContext _context;

        public CreateModel(MegaDesk_Razor.Models.MegaDesk_RazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task OnGetAsync()
        {
            // logic for building quote price based on other text input fields
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}