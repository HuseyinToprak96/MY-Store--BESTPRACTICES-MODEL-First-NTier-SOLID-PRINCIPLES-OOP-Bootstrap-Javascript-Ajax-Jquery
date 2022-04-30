using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
   public class SepetDetay
    {
        public int Id { get; set; }
        [ForeignKey("sepet")]
        public int? SepetId { get; set; }
        [ForeignKey("urun")]
        public int? UrunId { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public int Adet { get; set; }
        public  Sepet sepet { get; set; }
        public  Urun urun { get; set; }
    }
}
