using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Szallashely_foglalas_razer_pages.Data;
using Szallashely_foglalas_razer_pages.Models;

namespace Szallashely_foglalas_razer_pages.Pages.Szobak
{
    public class keresesModel : PageModel
    {
        private readonly PanzioContext _context;
        public keresesModel(PanzioContext context) => _context = context;

        [BindProperty(SupportsGet = true)]
        public DateTime? Erkezes { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? Tavozas { get; set; }

        public List<Szoba> SzabadSzobak { get; set; } = new();

        public async Task OnGetAsync()
        {
            if (Erkezes == null || Tavozas == null) return;

            if (Tavozas <= Erkezes)
            {
                ModelState.AddModelError(string.Empty, "A távozás napjának késõbbinek kell lennie, mint az érkezés.");
                return;
            }

            SzabadSzobak = await _context.Szobak
                .Where(szoba => !_context.Foglalasok.Any(f =>
                    f.SzobaId == szoba.Id &&
                    f.Erkezes < Tavozas &&
                    f.Tavozas > Erkezes
                ))
                .ToListAsync();
        }
    }
}
