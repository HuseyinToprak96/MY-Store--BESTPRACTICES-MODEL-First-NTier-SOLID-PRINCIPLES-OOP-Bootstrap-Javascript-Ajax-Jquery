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
        }
    }
}
