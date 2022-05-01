using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using StoreWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWeb.Controllers
{
    public class UrunController : Controller
    {
        private readonly IUrunService _UrunService;
        private readonly ISepetService _sepetService;
        private readonly IKategoriService _kategoriService;
        public UrunController(IUrunService urunService, ISepetService sepetService, IKategoriService kategoriService)
        {
            _UrunService = urunService;
            _sepetService = sepetService;
            _kategoriService = kategoriService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _UrunService.TumUrunBilgileri());
        }
        public async Task<IActionResult> Detay(int id)
        {
           var urun= await _UrunService.UrunDetay(id);
            var onerilen = await _UrunService.OnerilenUrunler(urun.CinsiyetId, urun.AltKategoriId);
            onerilen.Remove(urun);
            UrunVeBenzerUrunler urunVeBenzerUrunler = new UrunVeBenzerUrunler();
            urunVeBenzerUrunler.urun = urun;
            urunVeBenzerUrunler.BenzerUrunler = onerilen;
            urunVeBenzerUrunler.sepet =await _sepetService.MusterininSepeti(1);
            urunVeBenzerUrunler.kategoriler = await _kategoriService.KategoriyeAitDetaylar();
            return View(urunVeBenzerUrunler);
        }
        public async Task<IActionResult> Urunler(Source source)
        {
            return View(await _UrunService.Arama(source));
        }
    }
}
