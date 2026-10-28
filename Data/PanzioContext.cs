using Microsoft.EntityFrameworkCore;
using Szallashely_foglalas_razer_pages.Models;

namespace Szallashely_foglalas_razer_pages.Data
{
    public class PanzioContext : DbContext
    {
        public PanzioContext(DbContextOptions<PanzioContext> options) : base(options) { }

        public DbSet<Szoba> Szobak { get; set; }
        public DbSet<Foglalas> Foglalasok { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Szoba>()
                .HasIndex(s => s.Szam)
                .IsUnique();
        }
    }
}
