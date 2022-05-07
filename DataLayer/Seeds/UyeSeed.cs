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
    public class UyeSeed : IEntityTypeConfiguration<Uye>
    {
        public void Configure(EntityTypeBuilder<Uye> builder)
        {
            builder.HasData(new Uye
            {
 Ad="hüseyin", Soyad="Toprak", Mail="hsyn@hotmail.com", Telefon="53649445", Sifre="123", Adres="Kadıköy", Id=1, Yetki=true
            });
        }
    }
}
