using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Dtos
{
    public class SiparisDto
    {
        public int Id { get; set; }
        public string SiparisKodu { get; set; }
        public int UyeId { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public Durum SiparisDurumu { get; set; }
    }
}
