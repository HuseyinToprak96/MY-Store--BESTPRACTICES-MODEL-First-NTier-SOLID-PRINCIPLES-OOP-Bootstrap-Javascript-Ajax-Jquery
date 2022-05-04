using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
