using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations
{
    class UyeConfiguration : IEntityTypeConfiguration<Uye>
    {
        public void Configure(EntityTypeBuilder<Uye> builder)
        {
            builder.Property(x => x.Ad).HasMaxLength(25);
            builder.Property(x => x.Soyad).HasMaxLength(25);
            builder.Property(x => x.Adres).HasMaxLength(300);
            builder.Property(x => x.Mail).IsRequired();
            builder.Property(x => x.Telefon).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Sifre).IsRequired().HasMaxLength(20);
        }
    }
}
