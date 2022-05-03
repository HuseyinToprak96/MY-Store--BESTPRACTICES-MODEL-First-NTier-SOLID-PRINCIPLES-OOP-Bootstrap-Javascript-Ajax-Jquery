using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
   public class FaturaDetay
    {
        public int Id { get; set; }
        [ForeignKey("fatura")]
        public int? FaturaId { get; set; }
        [ForeignKey("urun")]
        public int? UrunId { get; set; }
        public double Fiyat { get; set; }
        public int Adet { get; set; }
        public Urun urun { get; set; }
        public Fatura fatura { get; set; }
    }
}
