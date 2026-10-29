using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Szallashely_foglalas_razer_pages.Data;
using Szallashely_foglalas_razer_pages.Models;

namespace Szallashely_foglalas_razer_pages.Pages.Foglalasok
{
    public class CreateModel : PageModel
    {
        private readonly Szallashely_foglalas_razer_pages.Data.PanzioContext _context;

        public CreateModel(Szallashely_foglalas_razer_pages.Data.PanzioContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SzobaId"] = new SelectList(_context.Szobak, "Id", "Szam");
            return Page();
        }

        [BindProperty]
        public Foglalas Foglalas { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["SzobaId"] = new SelectList(_context.Szobak, "Id", "Szam");
                return Page();
            }

            //  tav es erkezes
            if (Foglalas.Tavozas <= Foglalas.Erkezes)
            {
                ModelState.AddModelError("Foglalas.Tavozas", "A távozás dátumának későbbinek kell lennie, mint az érkezés!");
            }

            // ferohely ell
            var szoba = await _context.Szobak.FindAsync(Foglalas.SzobaId);
            if (szoba != null)
            {
                
                if (Foglalas.Letszam > szoba.Ferohely)
                {
                    ModelState.AddModelError("Foglalas.Letszam", $"A megadott létszám ({Foglalas.Letszam} fő) meghaladja a szoba férőhelyét ({szoba.Ferohely} fő)!");
                }
            }

            if (!ModelState.IsValid)
            {
                ViewData["SzobaId"] = new SelectList(_context.Szobak, "Id", "Szam");
                return Page();
            }

            _context.Foglalasok.Add(Foglalas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
