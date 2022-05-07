using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
    public class Siparis_Siparis_Detay_UrunDto:SiparisDto
    {
        public List<Siparis_Detay_Urun> siparisDetaylar { get; set; }
    }
}
