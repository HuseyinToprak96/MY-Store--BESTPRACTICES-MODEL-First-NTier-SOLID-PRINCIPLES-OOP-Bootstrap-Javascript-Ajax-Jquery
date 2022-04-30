using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configurations
{
    public class AltKategoriConfiguration : IEntityTypeConfiguration<AltKategori>
    {
        public void Configure(EntityTypeBuilder<AltKategori> builder)
        {
            builder.Property(x => x.AltKategoriAdi).HasMaxLength(120);
            builder.Property(x => x.Renk).HasMaxLength(30);
        }
    }
}
