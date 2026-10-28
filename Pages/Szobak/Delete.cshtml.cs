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
    public class DeleteModel : PageModel
    {
        private readonly Szallashely_foglalas_razer_pages.Data.PanzioContext _context;

        public DeleteModel(Szallashely_foglalas_razer_pages.Data.PanzioContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var szoba = await _context.Szobak.FindAsync(id);
            if (szoba != null)
            {
                Szoba = szoba;
                _context.Szobak.Remove(Szoba);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
