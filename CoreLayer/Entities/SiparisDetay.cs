using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
    public class SiparisDetay
    {
        public int Id { get; set; }
        [ForeignKey("urun")]
        public int urunId { get; set; }
        [ForeignKey("siparis")]
        public int SiparisId { get; set; }
        public double Fiyat { get; set; }
        public Urun urun { get; set; }
        public Siparis siparis { get; set; }
    }
}
