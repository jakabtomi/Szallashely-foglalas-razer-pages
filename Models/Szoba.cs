using System.ComponentModel.DataAnnotations;

namespace Szallashely_foglalas_razer_pages.Models
{
    public class Szoba
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A szobaszám megadása kötelező!")]
        [Display(Name = "Szobaszám")]
        public string Szam { get; set; } = string.Empty;

        [Range(1, 10, ErrorMessage = "A férőhelynek 1 és 10 között kell lennie!")]
        [Display(Name = "Férőhely (fő)")]
        public int Ferohely { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Éjszakai Ár (Ft)")]
        public decimal EjszakaiAr { get; set; }

        [Display(Name = "Leírás")]
        public string? Leiras { get; set; }

        public List<Foglalas> Foglalasok { get; set; } = new();
    }
}
