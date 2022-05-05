using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace StoreWeb.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAltKategoriService _altKategoriService;
        private readonly IUyeService _uyeService;
        private readonly IUrunService _urunService;
        private readonly IKategoriService _KategoriService;
        private readonly IMapper _mapper;
        public AdminController(IAltKategoriService altKategoriService, IUyeService uyeService, IUrunService urunService, IKategoriService kategoriService, IMapper mapper)
        {
            _altKategoriService = altKategoriService;
            _uyeService = uyeService;
            _urunService = urunService;
            _KategoriService = kategoriService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _KategoriService.KategoriyeAitDetaylar());
        }
        [HttpPost]
        public async Task<JsonResult> UrunEkle(Urun urun)
        {
            await _urunService.AddAsync(urun);
            return Json(urun);
        }
        [HttpPost]
        public async Task<JsonResult> urunSil(int id)
        {
            var urun = await _urunService.getByIdAsync(id);
            await _urunService.Remove(urun);
            return Json(id);
        }
        public IActionResult Kategoriler()
        {
            return View();
        }
        public async Task<JsonResult> KategoriEkle(KategoriDto kategoriDto)
        {
            var kategori = _mapper.Map<Kategori>(kategoriDto);
            await _KategoriService.AddAsync(kategori);
            return Json(kategoriDto.KategoriAdi);
        }
        [HttpPost]
        public async Task<JsonResult> kategoriSil(int id)
        {
            var kategori = await _urunService.getByIdAsync(id);
            await _urunService.Remove(kategori);
            return Json(id);
        }
        
        public async Task<JsonResult> altKategoriEkle(AltKategoriDto altKategoriDto)
        {
            var altKategori = _mapper.Map<AltKategori>(altKategoriDto);
            await _altKategoriService.AddAsync(altKategori);
            return Json(altKategori);
        }
        [HttpPost]
        public async Task<JsonResult> altKategoriSil(int id)
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
