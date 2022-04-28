using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
   public class Sepet
    {
        public int Id { get; set; }
        [ForeignKey("uye")]
        public int UyeId { get; set; }
        public virtual Uye uye { get; set; }
        public virtual List<SepetDetay> SepetDetay { get; set; }
    }
}
