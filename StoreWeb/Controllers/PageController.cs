using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace StoreWeb.Controllers
{
    [AllowAnonymous]
    public class PageController : Controller
    {
        private readonly IService<KimeGore> _KimeGoreservice;
        private readonly IKategoriService _kategoriService;
        private readonly IUrunService _urunService;

        public PageController(IService<KimeGore> kimeGoreservice, IKategoriService kategoriService, IUrunService urunService)
        {
            _KimeGoreservice = kimeGoreservice;
            _kategoriService = kategoriService;
            _urunService = urunService;


        }


        public async Task<IActionResult> Index()
        {
            VMIndex vMIndex = new VMIndex();
            vMIndex.Urunler = await _urunService.getAllAsync();
            vMIndex.Kategoriler = await _kategoriService.KategoriyeAitDetaylar();
            vMIndex.kimeGore = await _KimeGoreservice.getAllAsync();
            vMIndex.BitmesiYakinUrunler = await _urunService.BitmesiYakin();
            vMIndex.EnCokSatanlar = await _urunService.EncokSatan();
            vMIndex.FavoriUrunlar = _urunService.FavoriUrunler().Result;
            vMIndex.YeniGelenler = await _urunService.Yeni4Urun();
            return View(vMIndex);
        }
        public IActionResult Hakkimizda() => View();
        public IActionResult İletisim() => View();
        public IActionResult Magazalarimiz() => View();
        public IActionResult İnsanKaynaklari() => View();
        public IActionResult Kariyer() => View();
        public IActionResult KariyerFirsatlari() => View();
        public IActionResult Koleksiyonlar() => View();
    }
}
