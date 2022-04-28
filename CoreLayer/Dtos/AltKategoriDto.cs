using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
   public class AltKategoriDto
    {
        public int Id { get; set; }
        public string AltKategoriAdi { get; set; }
        public int KategoriId { get; set; }
    }
}
