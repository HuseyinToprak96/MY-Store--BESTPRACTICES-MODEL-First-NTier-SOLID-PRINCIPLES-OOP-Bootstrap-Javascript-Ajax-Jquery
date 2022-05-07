using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Seeds
{
    public class CinsiyetSeed : IEntityTypeConfiguration<KimeGore>
    {
        public void Configure(EntityTypeBuilder<KimeGore> builder)
        {
            builder.HasData(new KimeGore { Id = 1, kimeGore = "Kadın" },
                new KimeGore { Id = 2,  kimeGore = "Erkek" },
                new KimeGore { Id = 3, kimeGore= "Kız Çocuk" },
                new KimeGore { Id = 4, kimeGore = "Erkek Çocuk" });
        }
    }
}
