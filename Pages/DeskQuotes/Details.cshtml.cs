using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk_WebApp.Data;
using MegaDesk_WebApp.Models;

namespace MegaDesk_WebApp.Pages.DeskQuotes
{
    public class DetailsModel : PageModel
    {
        private readonly MegaDesk_WebApp.Data.MegaDesk_WebAppContext _context;

        public DetailsModel(MegaDesk_WebApp.Data.MegaDesk_WebAppContext context)
        {
            _context = context;
        }

      public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DeskQuote == null)
            {
                return NotFound();
            }

            var deskquote = await _context.DeskQuote.FirstOrDefaultAsync(m => m.id == id);
            if (deskquote == null)
            {
                return NotFound();
            }
            else 
            {
                DeskQuote = deskquote;
            }
            return Page();
        }
    }
}
