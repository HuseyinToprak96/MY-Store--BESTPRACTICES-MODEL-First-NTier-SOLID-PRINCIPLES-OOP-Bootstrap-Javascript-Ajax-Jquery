using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Entities
{
    public class Urun
    {
        public int Id { get; set; }
        public string Resim { get; set; }
        public string UrunAdi { get; set; }
        public double Ucret { get; set; }
        public string Beden { get; set; }
        public int Adet { get; set; }
        [ForeignKey("altKategori")]
        public int? AltKategoriId { get; set; }
        [ForeignKey("kimeGore")]
        public int? kimeGoreId { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public KimeGore kimeGore { get; set; }
        public List<SepetDetay> sepetDetay { get; set; }
        public List<FaturaDetay> FaturaDetay { get; set; }
        public List<SiparisDetay> SiparisDetay { get; set; }
        public AltKategori altKategori { get; set; }
    }
}
