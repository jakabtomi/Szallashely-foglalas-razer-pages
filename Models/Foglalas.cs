using System.ComponentModel.DataAnnotations;

namespace Szallashely_foglalas_razer_pages.Models
{
    public class Foglalas
    {
        public int Id { get; set; }

        [Display(Name = "Szoba")]
        public int SzobaId { get; set; }
        public Szoba? Szoba { get; set; }

        [Required(ErrorMessage = "A vendég nevének megadása kötelező!")]
        [Display(Name = "Vendég Neve")]
        public string VendegNev { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Érkezés")]
        public DateTime Erkezes { get; set; } = DateTime.Today;

        [DataType(DataType.Date)]
        [Display(Name = "Távozás")]
        public DateTime Tavozas { get; set; } = DateTime.Today.AddDays(1);

        [Range(1, 10, ErrorMessage = "A létszámnak legalább 1 főnek kell lennie!")]
        [Display(Name = "Létszám (fő)")]
        public int Letszam { get; set; }

        [Display(Name = "Állapot")]
        public string Allapot { get; set; } = "Aktív";

        public int EjszakakSzama => (Tavozas - Erkezes).Days;
        public decimal Vegosszeg => EjszakakSzama > 0 ? EjszakakSzama * (Szoba?.EjszakaiAr ?? 0) : 0;
    }
}
