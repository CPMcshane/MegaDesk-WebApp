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
    public class IndexModel : PageModel
    {
        private readonly MegaDesk_WebApp.Data.MegaDesk_WebAppContext _context;

        public IndexModel(MegaDesk_WebApp.Data.MegaDesk_WebAppContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DeskQuote != null)
            {
                DeskQuote = await _context.DeskQuote.ToListAsync();
            }
        }
    }
}
