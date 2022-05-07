using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWeb.Filters;
using System.IO;
using System.Threading.Tasks;

namespace StoreWeb.Controllers
{
   // [FilterStatus]
    public class AdminController : Controller
    {
        private readonly IAltKategoriService _altKategoriService;
        private readonly IUyeService _uyeService;
        private readonly IUrunService _urunService;
        private readonly IKategoriService _KategoriService;
        private readonly IMapper _mapper;
        private readonly ISiparisService _siparisService;
        private readonly IService<KimeGore> _CinsiyetService;
        public AdminController(IAltKategoriService altKategoriService, IUyeService uyeService, IUrunService urunService, IKategoriService kategoriService, IMapper mapper, ISiparisService siparisService, IService<KimeGore> cinsiyetService)
        {
            _altKategoriService = altKategoriService;
            _uyeService = uyeService;
            _urunService = urunService;
            _KategoriService = kategoriService;
            _mapper = mapper;
            _siparisService = siparisService;
            _CinsiyetService = cinsiyetService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["KimeGore"] =await _CinsiyetService.getAllAsync();
            TempData["AltKategoriler"] = await _altKategoriService.getAllAsync();
            return View(await _KategoriService.KategoriyeAitDetaylar());
        }
        [HttpPost]
        public async Task<JsonResult> UrunEkle(Urun urun)
        {
            //IFormFile formFile //Resim yükleme
            //var newName = Path.GetExtension(formFile.FileName);
            //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newName);
            //var stream = new FileStream(path, FileMode.Create);
            //await formFile.CopyToAsync(stream);
             //return Created(string.Empty,formFile)
            await _urunService.AddAsync(urun);
            return Json(urun.Id);
        }
        [HttpPost]
        public async Task<JsonResult> urunSil(int id)
        {
            var urun = await _urunService.getByIdAsync(id);
            await _urunService.Remove(urun);
            
            return Json(id);
        }
        [HttpPost]
        public async Task<JsonResult> UrunGuncelle(Urun urun)
        {
            await _urunService.Update(urun);
            return Json(urun.Id);
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
            var altKategoriler =await _altKategoriService.KategoriyeAitAltKategoriler(id);
            if (altKategoriler != null) {
                foreach (var altKategori in altKategoriler) {
                    var urunler =await _urunService.AltKategoriyeGore(altKategori.Id);
                    if(urunler!=null)
                    {
                        foreach (var urun in urunler)
                         await   _urunService.Remove(urun);
                    }
                   await _altKategoriService.Remove(altKategori);
               }
            }
            var kategori = await _KategoriService.getByIdAsync(id);
            await _KategoriService.Remove(kategori);
            return Json(id);
        }

        [HttpPost]
        public async Task<JsonResult> KategoriGuncelle(KategoriUpdateDto kategoriUpdateDto)
        {
            var kategori = _mapper.Map<Kategori>(kategoriUpdateDto);
            await _KategoriService.Update(kategori);
            return Json(kategori.Id);
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
            var urunler =await _urunService.AltKategoriyeGore(id);
            if (urunler != null) { 
            foreach (var urun in urunler)
               await _urunService.Remove(urun);
            }

            var altKategori = await _altKategoriService.getByIdAsync(id);
            await _altKategoriService.Remove(altKategori);
            return Json(id);
        }
        [HttpPost]
        public async Task<JsonResult> AltKategoriGuncelle(AltKategori altKategori)
        {
            await _altKategoriService.Update(altKategori);
            return Json(altKategori.Id);
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
        public async Task<IActionResult> SiparisDetay(int id)
        {
            TempData["Siparisler"] = await _siparisService.getAllAsync();
            return View(await _siparisService.SiparisDetay(id));
        }

    }
}
