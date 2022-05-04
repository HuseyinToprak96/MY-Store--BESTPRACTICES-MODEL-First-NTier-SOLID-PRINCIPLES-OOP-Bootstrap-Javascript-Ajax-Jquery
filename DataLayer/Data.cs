using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataLayer
{
    public class Data : DbContext
    {
        public Data(DbContextOptions<Data> options) : base(options)
        {

        }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<AltKategori> AltKategoriler { get; set; }
        public DbSet<Cinsiyet> Cinsiyetler { get; set; }
        public DbSet<Fatura> Faturalar { get; set; }
        public DbSet<FaturaDetay> FaturaDetaylar { get; set; }
        public DbSet<Sepet> Sepetler { get; set; }
        public DbSet<SepetDetay> SepetDetaylar { get; set; }
        public DbSet<Uye> Uyeler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
