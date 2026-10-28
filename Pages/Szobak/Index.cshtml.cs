using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Szallashely_foglalas_razer_pages.Data;
using Szallashely_foglalas_razer_pages.Models;

namespace Szallashely_foglalas_razer_pages.Pages.Szobak
{
    public class IndexModel : PageModel
    {
        private readonly Szallashely_foglalas_razer_pages.Data.PanzioContext _context;

        public IndexModel(Szallashely_foglalas_razer_pages.Data.PanzioContext context)
        {
            _context = context;
        }

        public IList<Szoba> Szoba { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Szoba = await _context.Szobak.ToListAsync();
        }
    }
}
