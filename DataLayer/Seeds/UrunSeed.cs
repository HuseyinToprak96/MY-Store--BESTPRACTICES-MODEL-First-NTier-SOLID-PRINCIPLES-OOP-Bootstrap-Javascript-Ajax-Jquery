using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataLayer.Seeds
{
    public class UrunSeed : IEntityTypeConfiguration<Urun>
    {
        public void Configure(EntityTypeBuilder<Urun> builder)
        {
            builder.HasData(new Urun { Id = 1, UrunAdi = "Basketbol Baskılı Tshirt", Adet = 100, CinsiyetId = 1, Ucret = 49.90, Beden = "M", AltKategoriId = 1, Resim = "/img/basket.jpg" });
            builder.HasData(new Urun { Id = 2, UrunAdi = "Mavi Renk Desenli Salaş T-shirt", Adet = 100, AltKategoriId = 3, CinsiyetId = 4, Beden = "S", EklenmeTarihi = DateTime.Now, Ucret = 49.90, Resim = "/img/ErkekCocukSalasMaviDesenli.jpg" });
            builder.HasData(new Urun { Id = 3, UrunAdi = "Sari Renk Salaş  T-shirt", Adet = 100, AltKategoriId = 3, CinsiyetId = 4, Beden = "S", EklenmeTarihi = DateTime.Now, Ucret = 49.90, Resim = "/img/ErkekCocukSalasSari.jpg" });
            builder.HasData(new Urun { Id = 4, UrunAdi = "Füme Rengi Dik Yaka T-Shirt", Adet = 100, AltKategoriId = 2, CinsiyetId = 2, Beden = "L", EklenmeTarihi = DateTime.Now, Ucret = 89.90, Resim = "/img/ErkekDikYakaFume.jpg" });
            builder.HasData(new Urun { Id = 5, UrunAdi = "Beyaz Renk Salaş T-shirt", Adet = 100, AltKategoriId = 3, CinsiyetId = 2, Beden = "L", EklenmeTarihi = DateTime.Now, Ucret = 99.90, Resim = "/img/ErkekSalasBeyaz.jpg" });
            builder.HasData(new Urun { Id = 6, UrunAdi = "Yeşil Renk Salaş T-shirt", Adet = 100, AltKategoriId = 3, CinsiyetId = 2, Beden = "L", EklenmeTarihi = DateTime.Now, Ucret = 99.90, Resim = "/img/ErkekSalasYEsil.jpg" });
            builder.HasData(new Urun { Id = 7, UrunAdi = "Mor Renk V Yaka T-shirt", Adet = 100, AltKategoriId = 1, CinsiyetId = 2, Beden = "L", EklenmeTarihi = DateTime.Now, Ucret = 79.90, Resim = "/img/ErkekVMor.jpg" });
            builder.HasData(new Urun { Id = 8, UrunAdi = "Siyah Renk V Yaka T-shirt", Adet = 100, AltKategoriId = 1, CinsiyetId = 1, Beden = "M", EklenmeTarihi = DateTime.Now, Ucret = 79.90, Resim = "/img/KadinVSiyah.jpg" });
            builder.HasData(new Urun { Id = 9, UrunAdi = "Yeşil Renk V Yaka T-shirt", Adet = 100, AltKategoriId = 1, CinsiyetId = 1, Beden = "M", EklenmeTarihi = DateTime.Now, Ucret = 79.90, Resim = "/img/KadinVYesil.jpg" });
            builder.HasData(new Urun { Id = 10, UrunAdi = "Beyaz Renk Dik Yaka T-shirt", Adet = 100, AltKategoriId = 2, CinsiyetId = 1, Beden = "M", EklenmeTarihi = DateTime.Now, Ucret = 89.90, Resim = "/img/KadinDikYakaBeyaz.jpg" });
            builder.HasData(new Urun { Id = 11, UrunAdi = "Gri Renk Dik Yaka T-shirt", Adet = 100, AltKategoriId = 2, CinsiyetId = 1, Beden = "M", EklenmeTarihi = DateTime.Now, Ucret = 89.90, Resim = "/img/KadinDikYakaGri.jpg" });
            builder.HasData(new Urun { Id = 12, UrunAdi = "Krem Rengi Düz Yaka T-shirt", Adet = 100, AltKategoriId = 4, CinsiyetId = 1, Beden = "M", EklenmeTarihi = DateTime.Now, Ucret = 109.90, Resim = "/img/KadinDuzYakaKrem.jpg" });
            builder.HasData(new Urun { Id = 13, UrunAdi = "Beyaz Renk Salaş T-shirt", Adet = 100, AltKategoriId = 3, CinsiyetId = 1, Beden = "M", EklenmeTarihi = DateTime.Now, Ucret = 99.90, Resim = "/img/KadinSalasBeyaz.jpg" });
            builder.HasData(new Urun { Id = 14, UrunAdi = "Kırmızı Renk Salaş T-shirt", Adet = 100, AltKategoriId = 3, CinsiyetId = 1, Beden = "M", EklenmeTarihi = DateTime.Now, Ucret = 99.90, Resim = "/img/KadinSalasKirmizi.jpg" });
            builder.HasData(new Urun { Id = 15, UrunAdi = "Beyaz Desenli Salaş T-shirt", Adet = 100, AltKategoriId = 2, CinsiyetId = 3, Beden = "S", EklenmeTarihi = DateTime.Now, Ucret = 49.90, Resim = "/img/KizCocukSalasBeyazDesenli.jpg" });
            builder.HasData(new Urun { Id = 16, UrunAdi = "Never Desenli Salaş T-shirt", Adet = 100, AltKategoriId = 2, CinsiyetId = 3, Beden = "S", EklenmeTarihi = DateTime.Now, Ucret = 49.90, Resim = "/img/KizCocukSalasNeverDesenli.jpg" });






        }
    }
}
