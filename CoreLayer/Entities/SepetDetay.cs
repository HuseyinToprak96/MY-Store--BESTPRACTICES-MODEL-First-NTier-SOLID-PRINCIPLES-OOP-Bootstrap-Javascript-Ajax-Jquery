using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Entities
{
    public class SepetDetay
    {
        public int Id { get; set; }
        [ForeignKey("sepet")]
        public int SepetId { get; set; }
        [ForeignKey("urun")]
        public int UrunId { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public int Adet { get; set; }
        public Sepet sepet { get; set; }
        public Urun urun { get; set; }
    }
}
