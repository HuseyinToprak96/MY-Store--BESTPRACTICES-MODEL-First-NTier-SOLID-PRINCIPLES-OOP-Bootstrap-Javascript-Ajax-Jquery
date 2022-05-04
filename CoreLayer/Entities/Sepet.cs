using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreLayer.Entities
{
    public class Sepet
    {
        public int Id { get; set; }
        [ForeignKey("uye")]
        public int UyeId { get; set; }
        public Uye uye { get; set; }
        public List<SepetDetay> SepetDetay { get; set; }
    }
}
