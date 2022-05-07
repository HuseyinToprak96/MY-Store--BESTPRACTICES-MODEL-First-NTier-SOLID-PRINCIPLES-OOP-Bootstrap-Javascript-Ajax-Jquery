using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWeb.Filters;
using StoreWeb.ViewModels;
using System.Threading.Tasks;
using X.PagedList;

namespace StoreWeb.Controllers
{
    [AllowAnonymous]
    public class UrunController : Controller
    {
        private readonly IUrunService _UrunService;
        private readonly ISepetService _sepetService;
        private readonly IKategoriService _kategoriService;
        private readonly IService<KimeGore> _KimeGoreService;
        private readonly IAltKategoriService _altKategoriService;
        public UrunController(IUrunService urunService, ISepetService sepetService, IKategoriService kategoriService, IService<KimeGore> KimeGoreService, IAltKategoriService altKategoriService)
        {
            _UrunService = urunService;
            _sepetService = sepetService;
            _kategoriService = kategoriService;
            _KimeGoreService = KimeGoreService;
            _altKategoriService = altKategoriService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _UrunService.TumUrunBilgileri());
        }
        [FilterLogin]
        public async Task<IActionResult> Detay(int id)
        {
            int Userid = HttpContext.Session.GetInt32("ID").Value;
            var urun = await _UrunService.UrunDetay(id);
            var onerilen = await _UrunService.OnerilenUrunler(urun.kimeGoreId, urun.AltKategoriId);
            onerilen.Remove(urun);
            UrunVeBenzerUrunler urunVeBenzerUrunler = new UrunVeBenzerUrunler();
            urunVeBenzerUrunler.urun = urun;
            urunVeBenzerUrunler.BenzerUrunler = onerilen;
            urunVeBenzerUrunler.sepet = await _sepetService.MusterininSepeti(Userid);
            urunVeBenzerUrunler.kimeGore = await _KimeGoreService.getAllAsync();
            return View(urunVeBenzerUrunler);
        }
        public async Task<IActionResult> Urunler(Source source, int page = 1)
        {
            VM_Urunler vM_Urunler = new VM_Urunler();
            var urunler = _UrunService.Arama(source);
            vM_Urunler.Urunler = urunler.Result.ToPagedList(page, 10);
            vM_Urunler.kimeGore = await _KimeGoreService.getAllAsync();
            vM_Urunler.AltKategoris = await _altKategoriService.getAllAsync();
            return View(vM_Urunler);
        }
    }
}
