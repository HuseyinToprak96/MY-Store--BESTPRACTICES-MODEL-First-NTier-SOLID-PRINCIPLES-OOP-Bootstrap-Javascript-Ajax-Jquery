using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Seeds
{
    public class KategoriSeed : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.HasData(new Kategori { Id = 1, KategoriAdi = "T-shirt", Renk = "red" });
            builder.HasData(new Kategori { Id = 2, KategoriAdi = "Gömlek", Renk = "gold" });
            builder.HasData(new Kategori { Id = 3, KategoriAdi = "Pantolon", Renk = "blue" });
            builder.HasData(new Kategori { Id = 4, KategoriAdi = "Ayakkabı", Renk = "black" });
        }
    }
}
