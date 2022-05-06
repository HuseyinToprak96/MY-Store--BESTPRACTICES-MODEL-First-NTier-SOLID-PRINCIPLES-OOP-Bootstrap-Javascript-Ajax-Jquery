using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreWeb.Filters;
using System.Threading.Tasks;

namespace StoreWeb.Controllers
{
    [FilterStatus]
    public class AdminController : Controller
    {
        private readonly IAltKategoriService _altKategoriService;
        private readonly IUyeService _uyeService;
        private readonly IUrunService _urunService;
        private readonly IKategoriService _KategoriService;
        private readonly IMapper _mapper;
        private readonly ISiparisService _siparisService;
        public AdminController(IAltKategoriService altKategoriService, IUyeService uyeService, IUrunService urunService, IKategoriService kategoriService, IMapper mapper, ISiparisService siparisService)
        {
            _altKategoriService = altKategoriService;
            _uyeService = uyeService;
            _urunService = urunService;
            _KategoriService = kategoriService;
            _mapper = mapper;
            _siparisService = siparisService;
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
            return Json(kategori.Id);
        }
        [HttpPost]
        public async Task<JsonResult> kategoriSil(int id)
        {
            var kategori = await _KategoriService.getByIdAsync(id);
            await _KategoriService.Remove(kategori);
            return Json(id);
        }
        
        public async Task<JsonResult> altKategoriEkle(AltKategoriDto altKategoriDto)
        {
            var altKategori = _mapper.Map<AltKategori>(altKategoriDto);
            await _altKategoriService.AddAsync(altKategori);
            return Json(altKategori.Id);
        }
        [HttpPost]
        public async Task<JsonResult> altKategoriSil(int id)
        {
            var altKategori = await _altKategoriService.getByIdAsync(id);
            await _altKategoriService.Remove(altKategori);
            return Json(altKategori);
        }
        public async Task<IActionResult> Kullanicilar()
        {
            return View(await _uyeService.getAllAsync());
        }
        [HttpPost]
        public async Task<JsonResult> UyeYetkilendirme(bool yetki, int id)
        {
            await _uyeService.Yetkilendir(yetki, id);
            return Json(yetki);
        }
        public async Task<IActionResult> SiparisDurumu(int id)
        {
            Durum durum = (Durum)id;
        //siparisle ilgili işlemler değişmeyeceğinden enum içerisinde tuttuk
            TempData["siparisler"] =await _siparisService.Siparisler(durum);
            
            //Tempdata ile taşıma sebebimiz eğer yeni sipariş gelmiş ise altta bulunan metoddan dolayı bunun durumu 1 e getirilcek
            //yani görülmüş sipariş olacak. bundan dolayıda yeni gelen siparişleri göremeyiz.
            if (id == 0)
                await _siparisService.DurumGuncelle(id);
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> SiparisOlay(int durum,int id)
        { 
             await _siparisService.SiparisGuncelle(durum,id);
             return Json(durum);
        }

    }
}
