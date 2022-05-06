using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
    public enum Durum { Yeni=1, Hazirlanıyor=2,Kargoda=3,TeslimEdildi=4}
    public class Siparis
    {
        public int Id { get; set; }
        public string SiparisKodu { get; set; }
        [ForeignKey("uye")]
        public int UyeId { get; set; }
       // public int Puan { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public Durum SiparisDurumu { get; set; }
        public Uye uye { get; set; }
        public List<SiparisDetay> siparisDetay { get; set; }
    }
}
