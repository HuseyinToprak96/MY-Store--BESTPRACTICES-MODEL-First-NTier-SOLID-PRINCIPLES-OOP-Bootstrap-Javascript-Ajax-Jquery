using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    class UrunConfiguration : IEntityTypeConfiguration<Urun>
    {
        public void Configure(EntityTypeBuilder<Urun> builder)
        {
            builder.Property(x => x.UrunAdi).IsRequired().HasMaxLength(120);
            builder.Property(x => x.Ucret).IsRequired().HasColumnType("decimal(18,2)");
        }
    }
}
