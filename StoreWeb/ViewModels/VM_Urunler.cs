using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace StoreWeb.ViewModels
{
    public class VM_Urunler
    {
        public IPagedList<Urun> Urunler { get; set; }
        public List<AltKategori> AltKategoris  { get; set; }
        public List<Cinsiyet> Cinsiyetler { get; set; }
    }
}
