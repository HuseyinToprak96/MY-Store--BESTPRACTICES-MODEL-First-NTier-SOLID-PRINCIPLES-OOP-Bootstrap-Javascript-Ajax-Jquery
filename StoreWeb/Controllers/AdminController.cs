using AutoMapper;
using CacheLayer;
using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWeb.Controllers
{
 
    public class AdminController : Controller
    {
        private readonly IAltKategoriService _altKategoriService;
        private readonly IUyeService _uyeService;
        private readonly UrunServiceWithCaching _urunService;
        private readonly IService<Kategori> _KategoriService;
        private readonly IMapper _mapper;
        public AdminController(IAltKategoriService altKategoriService, IUyeService uyeService, UrunServiceWithCaching urunService, IService<Kategori> kategoriService, IMapper mapper)
        {
            _altKategoriService = altKategoriService;
            _uyeService = uyeService;
            _urunService = urunService;
            _KategoriService = kategoriService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> UrunEkle(Urun urun)
        {
           await _urunService.AddAsync(urun);
            return Json(urun);
        }
        [HttpPost]
        public async Task<JsonResult> UrunSil(int id)
        {
            var urun = await _urunService.getByIdAsync(id);
           await _urunService.Remove(urun);
            return Json(urun);
        }
        public IActionResult Kategoriler()
        {
            return View();
        }
        public async Task<IActionResult> KategoriEkle()
        {
            return View(await _KategoriService.getAllAsync());
        }
        [HttpPost]
        public async Task<JsonResult> KategoriSil(int id)
        {
            var urun = await _urunService.getByIdAsync(id);
           await _urunService.Remove(urun);
            return Json(urun);
        }
        public IActionResult AltKategoriler()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> AltKategoriEkle(AltKategori altKategori)
        {
            await _altKategoriService.AddAsync(altKategori);
            return Json(altKategori);
        }
        [HttpPost]
        public async Task<JsonResult> AltKategoriSil(int id)
        {
            var altKategori = await _altKategoriService.getByIdAsync(id);
           await _altKategoriService.Remove(altKategori);
            return Json(altKategori);
        }
        public async Task<IActionResult> Uyeler()
        {
            return View(await _uyeService.getAllAsync());
        }
        [HttpPost]
        public async Task<JsonResult> UyeYetkilendirme(bool yetki, int id)
        {
            await _uyeService.Yetkilendir(yetki, id);
            return Json(yetki);
        }
     
      
    }
}
