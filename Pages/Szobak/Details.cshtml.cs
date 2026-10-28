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
    public class DetailsModel : PageModel
    {
        private readonly Szallashely_foglalas_razer_pages.Data.PanzioContext _context;

        public DetailsModel(Szallashely_foglalas_razer_pages.Data.PanzioContext context)
        {
            _context = context;
        }

        public Szoba Szoba { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var szoba = await _context.Szobak.FirstOrDefaultAsync(m => m.Id == id);

            if (szoba is not null)
            {
                Szoba = szoba;

                return Page();
            }

            return NotFound();
        }
    }
}
