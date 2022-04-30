using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
   public class Fatura
    {
        public int Id { get; set; }
        [ForeignKey("uye")]
        public int UyeId { get; set; }
        public DateTime AlisverisTarihi { get; set; }
        public  Uye uye { get; set; }
        public  List<FaturaDetay> faturaDetays { get; set; }
    }
}
