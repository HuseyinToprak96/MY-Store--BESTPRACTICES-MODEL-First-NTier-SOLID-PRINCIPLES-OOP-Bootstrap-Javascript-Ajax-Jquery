using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities
{
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
        [ForeignKey("cinsiyet")]
        public int CinsiyetId { get; set; }
        public virtual Cinsiyet cinsiyet { get; set; }
        public virtual Sepet sepet { get; set; }
        public virtual List<Fatura> Faturalar { get; set; }
    }
}
