using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Seeds
{
    public class AltKategoriSeed : IEntityTypeConfiguration<AltKategori>
    {
        public void Configure(EntityTypeBuilder<AltKategori> builder)
        {
            builder.HasData(new AltKategori { Id = 1, AltKategoriAdi = "V Yaka", KategoriId = 1, Renk="darkblue" });
            builder.HasData(new AltKategori { Id = 2, AltKategoriAdi = "Dik Yaka", KategoriId = 1, Renk="orange" });
            builder.HasData(new AltKategori { Id = 3, AltKategoriAdi = "Salaş", KategoriId = 1, Renk="green" });
            builder.HasData(new AltKategori { Id = 4, AltKategoriAdi = "Düz Yaka", KategoriId = 1, Renk="pink" });


        }
    }
}
