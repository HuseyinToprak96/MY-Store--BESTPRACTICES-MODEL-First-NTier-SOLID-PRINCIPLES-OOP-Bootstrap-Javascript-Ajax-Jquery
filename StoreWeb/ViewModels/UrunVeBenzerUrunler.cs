using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWeb.ViewModels
{
    public class UrunVeBenzerUrunler
    {
        public Urun urun { get; set; }
        public List<Urun> BenzerUrunler { get; set; }
        public Sepet sepet { get; set; }
        public List<Cinsiyet> Cinsiyetler  { get; set; }
    }
}
