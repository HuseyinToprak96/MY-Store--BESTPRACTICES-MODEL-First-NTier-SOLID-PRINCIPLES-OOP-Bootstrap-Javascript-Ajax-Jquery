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
    class FaturaDetayConfiguration : IEntityTypeConfiguration<FaturaDetay>
    {
        public void Configure(EntityTypeBuilder<FaturaDetay> builder)
        {
            builder.Property(x => x.Fiyat).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
