using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
    public class SiparisDetailDto
    {
        public int Id { get; set; }
        public int urunId { get; set; }
        public int SiparisId { get; set; }
        public double Fiyat { get; set; }
    }
}
