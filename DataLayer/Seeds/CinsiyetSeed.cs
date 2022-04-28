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
    public class CinsiyetSeed : IEntityTypeConfiguration<Cinsiyet>
    {
        public void Configure(EntityTypeBuilder<Cinsiyet> builder)
        {
            builder.HasData(new Cinsiyet { Id = 1, cinsiyet = "Kadın" },
                new Cinsiyet { Id = 2, cinsiyet = "Erkek" },
                new Cinsiyet { Id=3, cinsiyet="Kız Çocuk" }, 
                new Cinsiyet { Id=4, cinsiyet="Erkek Çocuk" });
        }
    }
}
