using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Mvc.Core;
using StoreWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace StoreWeb.Controllers
{
    public class UrunController : Controller
    {
        private readonly IUrunService _UrunService;
        private readonly ISepetService _sepetService;
        private readonly IKategoriService _kategoriService;
        private readonly IService<Cinsiyet> _CinsiyetService;
        private readonly IAltKategoriService _altKategoriService;
        public UrunController(IUrunService urunService, ISepetService sepetService, IKategoriService kategoriService, IService<Cinsiyet> cinsiyetService, IAltKategoriService altKategoriService)
        {
            _UrunService = urunService;
            _sepetService = sepetService;
            _kategoriService = kategoriService;
            _CinsiyetService = cinsiyetService;
            _altKategoriService = altKategoriService;
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
        public JsonResult liste()
        {
            var urunler = _UrunService.getAllAsync().Result;
            return Json(urunler);
        }
        public async Task<IActionResult> Urunler(Source source,int page=1)
        {
            VM_Urunler vM_Urunler = new VM_Urunler();
            var urunler=  _UrunService.Arama(source);
            vM_Urunler.Urunler = (List<Urun>)urunler.Result.ToPagedList(page, 15);
            vM_Urunler.Cinsiyetler = await _CinsiyetService.getAllAsync();
            vM_Urunler.AltKategoris = await _altKategoriService.getAllAsync();
            return View(vM_Urunler);
        }
    }
}
