using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
   public class AltKategori
    {
        public int Id { get; set; }
        public string AltKategoriAdi { get; set; }
        public string Renk { get; set; }
        [ForeignKey("kategori")]
        public int KategoriId { get; set; }
        public Kategori kategori { get; set; }
        public List<Urun> Urunler { get; set; }
    }
}
