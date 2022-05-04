using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
