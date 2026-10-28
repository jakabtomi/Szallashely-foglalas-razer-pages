using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Szallashely_foglalas_razer_pages.Data;
using Szallashely_foglalas_razer_pages.Models;

namespace Szallashely_foglalas_razer_pages.Pages.Szobak
{
    public class EditModel : PageModel
    {
        private readonly Szallashely_foglalas_razer_pages.Data.PanzioContext _context;

        public EditModel(Szallashely_foglalas_razer_pages.Data.PanzioContext context)
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

            var szoba =  await _context.Szobak.FirstOrDefaultAsync(m => m.Id == id);
            if (szoba == null)
            {
                return NotFound();
            }
            Szoba = szoba;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Szoba).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SzobaExists(Szoba.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SzobaExists(int id)
        {
            return _context.Szobak.Any(e => e.Id == id);
        }
    }
}
