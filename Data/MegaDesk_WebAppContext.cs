using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDesk_WebApp.Models;

namespace MegaDesk_WebApp.Data
{
    public class MegaDesk_WebAppContext : DbContext
    {
        public MegaDesk_WebAppContext (DbContextOptions<MegaDesk_WebAppContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDesk_WebApp.Models.DeskQuote> DeskQuote { get; set; } = default!;
    }
}
