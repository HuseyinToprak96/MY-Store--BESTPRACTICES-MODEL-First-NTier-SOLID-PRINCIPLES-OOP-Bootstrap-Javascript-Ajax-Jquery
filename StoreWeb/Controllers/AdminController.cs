using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StoreWeb.Filters;
using System;
using System.IO;
using System.Threading.Tasks;

namespace StoreWeb.Controllers
{
    //[FilterStatus]
    public class AdminController : Controller
    {
        private readonly IAltKategoriService _altKategoriService;
        private readonly IUyeService _uyeService;
        private readonly IUrunService _urunService;
        private readonly IKategoriService _KategoriService;
        private readonly IMapper _mapper;
        private readonly ISiparisService _siparisService;
        private readonly IService<KimeGore> _kimeGoreService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminController(IAltKategoriService altKategoriService, IUyeService uyeService, IUrunService urunService, IKategoriService kategoriService, IMapper mapper, ISiparisService siparisService, IWebHostEnvironment webHostEnvironment, IService<KimeGore> kimeGoreService)
        {
            _altKategoriService = altKategoriService;
            _uyeService = uyeService;
            _urunService = urunService;
            _KategoriService = kategoriService;
            _mapper = mapper;
            _siparisService = siparisService;
            _webHostEnvironment = webHostEnvironment;
            _kimeGoreService = kimeGoreService;
        }
        public async Task<IActionResult> Index()
        {
           Durum durum = (Durum)0;
           TempData["YeniSiparisler"] =await _siparisService.Siparisler(durum);
           TempData["KimeGore"] =await _kimeGoreService.getAllAsync();
            var altKategoriler=await _altKategoriService.getAllAsync();
            if (altKategoriler != null)
                TempData["AltKategoriler"] = altKategoriler; 
            return View(await _KategoriService.KategoriyeAitDetaylar());
        }
        public async Task<IActionResult> Stok()
        {
            var urunler =await _urunService.StokKontrol(100);
            return View(urunler);
        }

        [HttpPost]
        public async Task<JsonResult> StokDegis(int id,int adet)
        {
            await _urunService.AdetGuncelle(adet, id);
            return Json(id);
        }

        [HttpPost]
        public async Task<IActionResult> UrunEkle(Urun urun,IFormFile formFile)
        {
            if (formFile != null)
            {
                string folder = "Products/";
                folder += Guid.NewGuid().ToString() + formFile.FileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await formFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                urun.Resim = folder;
            }
            urun.EklenmeTarihi = DateTime.Now;
            
            await _urunService.AddAsync(urun);
            return RedirectToAction("Index");
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
            var deger= await _siparisService.PuanOrt();
            int sayi=(int)((deger * 80) / 4);
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

        public IActionResult DosyaKontrol()
        {

            return View();
        }
        [HttpPost]
        public IActionResult DosyaKontrol(IFormFile formFile)
        {
            if (formFile!=null)
            {
                string folder = "Products/";
                folder += Guid.NewGuid().ToString()+formFile.FileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                formFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }
            return RedirectToAction("DosyaKontrol");
        }
        public async Task<CreatedResult> ResimEkle(IFormFile formFile)
        {
            var newName = Path.GetExtension(formFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newName);
            var stream = new FileStream(path, FileMode.Create);
            await formFile.CopyToAsync(stream);
            return Created(string.Empty, formFile);
            //return Json();
        }

    }
}
