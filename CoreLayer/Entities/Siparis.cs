using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
    public enum Durum { Yeni=0, Hazirlanıyor=1,Kargoda=2,TeslimEdildi=3}
    public enum Puanlama {Seç=0, Kötü=1, Orta=2, İyi=3, Çokİyi=4}
    public class Siparis
    {
        public int Id { get; set; }
        public string SiparisKodu { get; set; }
        [ForeignKey("uye")]
        public int UyeId { get; set; }
        public int Puan { get; set; } //KULLANICI SİPARİŞİ TESLİM ALDIKTAN SONRA OYLAYACAK
        public DateTime SiparisTarihi { get; set; }
        public Durum SiparisDurumu { get; set; }
        public Uye uye { get; set; }
        public List<SiparisDetay> siparisDetay { get; set; }
    }
}
