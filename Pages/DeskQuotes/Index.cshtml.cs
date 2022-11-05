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
        [BindProperty(SupportsGet =true)]
        public string ? SearchString { get; set; }
        [BindProperty(SupportsGet =true)]
        public string ? entry { get; set; }
        public async Task OnGetAsync()
        {
            
            var Deskquotes = from d in _context.DeskQuote select d;
            if (!string.IsNullOrEmpty(SearchString))
            {
                Deskquotes = Deskquotes.Where(s => s.CustomerName.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(entry))
            {
                switch (entry)
                {
                    case "name":
                        Deskquotes = Deskquotes.OrderBy(s => s.CustomerName);
                        break;
                    case "date":
                        Deskquotes = Deskquotes.OrderBy(s => s.DateAdded);
                        break;
                }
            }
            DeskQuote = await Deskquotes.ToListAsync();
        }

        public void OnPost()
        {

        }
    }
}
