using CoreLayer.Entities;
using System.Collections.Generic;

namespace StoreWeb.ViewModels
{
    public class VMIndex
    {
        public List<Urun> Urunler { get; set; }
        public List<Urun> EnCokSatanlar { get; set; }
        public List<Urun> FavoriUrunlar { get; set; }
        public List<Urun> YeniGelenler { get; set; }
        public List<Urun> BitmesiYakinUrunler { get; set; }
        public List<Kategori> Kategoriler { get; set; }
        public List<KimeGore> kimeGore { get; set; }

    }
}
