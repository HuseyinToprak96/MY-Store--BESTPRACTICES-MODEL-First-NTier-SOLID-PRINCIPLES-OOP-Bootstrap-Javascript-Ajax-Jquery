using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWeb.Controllers
{
    public class PageController : Controller
    {
        private readonly IService<Cinsiyet> _Cinsiyetservice;
        private readonly IKategoriService _kategoriService;
        private readonly IUrunService _urunService;

        public PageController(IService<Cinsiyet> cinsiyetservice, IKategoriService kategoriService, IUrunService urunService)
        {
            _Cinsiyetservice = cinsiyetservice;
            _kategoriService = kategoriService;
            _urunService = urunService;
        }

        public async Task<IActionResult> Index()
        {
            VMIndex vMIndex = new VMIndex();
            vMIndex.Urunler = await _urunService.getAllAsync();
            vMIndex.Kategoriler =await _kategoriService.KategoriyeAitDetaylar();
            vMIndex.Cinsiyetler = await _Cinsiyetservice.getAllAsync();
            vMIndex.BitmesiYakinUrunler = await _urunService.getAllAsync();
            vMIndex.EnCokSatanlar = await _urunService.getAllAsync();
            vMIndex.FavoriUrunlar = await _urunService.getAllAsync();
            vMIndex.YeniGelenler = await _urunService.getAllAsync();
            return View(vMIndex);
        }
    }
}
