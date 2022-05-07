using CoreLayer.Entities;
using System.Collections.Generic;

namespace StoreWeb.ViewModels
{
    public class UrunVeBenzerUrunler
    {
        public Urun urun { get; set; }
        public List<Urun> BenzerUrunler { get; set; }
        public Sepet sepet { get; set; }
        public List<KimeGore> kimeGore { get; set; }
    }
}
