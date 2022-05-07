using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Entities
{
    public enum Cinsiyet { Erkek=1, Kadın=2}
    public class Uye
    {
        public int Id { get; set; }
        public bool Yetki { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public Cinsiyet cinsiyet { get; set; }
        public Sepet sepet { get; set; }
        public List<Fatura> Faturalar { get; set; }
        public List<Siparis> Sipariler { get; set; }
    }
}
