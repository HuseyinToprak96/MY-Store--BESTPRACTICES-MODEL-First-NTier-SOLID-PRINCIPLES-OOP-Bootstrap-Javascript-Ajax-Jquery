using AutoMapper;
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

namespace Alısveris.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAltKategoriService _altKategoriService;
        private readonly IUyeService _uyeService;
        private readonly IUrunService _urunService;
        private readonly IService<Kategori> _KategoriService;
        private readonly IMapper _mapper;
        public AdminController(IAltKategoriService altKategoriService, IUyeService uyeService, IUrunService urunService, IService<Kategori> kategoriService, IMapper mapper)
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
            _urunService.Remove(urun);
            return Json(urun);
        }
        public IActionResult Kategoriler()
        {
            return View();
        }
        public IActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> KategoriEkle(KategoriDto kategoriDto)
        {
            var kategori = _mapper.Map<Kategori>(kategoriDto);
            await _KategoriService.AddAsync(kategori);
            return Json(kategori);
        }
        [HttpPost]
        public async Task<JsonResult> KategoriSil(int id)
        {
            var urun = await _urunService.getByIdAsync(id);
            _urunService.Remove(urun);
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
            _altKategoriService.Remove(altKategori);
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
