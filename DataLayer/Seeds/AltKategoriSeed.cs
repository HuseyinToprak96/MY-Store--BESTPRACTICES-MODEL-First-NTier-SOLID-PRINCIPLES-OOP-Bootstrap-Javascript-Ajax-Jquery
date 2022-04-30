using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Seeds
{
    public class AltKategoriSeed : IEntityTypeConfiguration<AltKategori>
    {
        public void Configure(EntityTypeBuilder<AltKategori> builder)
        {
            builder.HasData(new AltKategori { Id = 1, AltKategoriAdi = "V Yaka", KategoriId=1 });
            builder.HasData(new AltKategori { Id = 2, AltKategoriAdi = "Dik Yaka", KategoriId = 1 });
            builder.HasData(new AltKategori { Id = 3, AltKategoriAdi = "Salaş", KategoriId = 1 });
            builder.HasData(new AltKategori { Id = 4, AltKategoriAdi = "Düz Yaka", KategoriId = 1 });


        }
    }
}
