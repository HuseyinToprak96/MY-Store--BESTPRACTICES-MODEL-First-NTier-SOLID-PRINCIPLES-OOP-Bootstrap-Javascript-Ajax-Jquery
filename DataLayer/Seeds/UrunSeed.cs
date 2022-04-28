using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Seeds
{
    public class UrunSeed : IEntityTypeConfiguration<Urun>
    {
        public void Configure(EntityTypeBuilder<Urun> builder)
        {
            builder.HasData(new Urun { Id=1,UrunAdi = "Basketbol Baskılı Tshirt", Adet=100, CinsiyetId=1, Ucret=49.90, AltKategoriId=1, Resim="img/basket.jpg"});
        }
    }
}
