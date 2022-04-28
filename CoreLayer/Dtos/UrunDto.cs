using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
   public class UrunDto
    {
        public int Id { get; set; }
        public string Resim { get; set; }
        public string UrunAdi { get; set; }
        public double Ucret { get; set; }
        public int Adet { get; set; }
        public int AltKategoriId { get; set; }
        public int CinsiyetId { get; set; }
    }
}
