using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace StoreWeb.Controllers
{
    public class SepetController : Controller
    {
        private readonly ISepetService _SepetService;
        private readonly IService<SepetDetay> _service;
        private readonly Sepet _sepet;
        public SepetController(ISepetService sepetService, Sepet sepet, IService<SepetDetay> service)
        {
            _SepetService = sepetService;
            _sepet = sepet;
            _service = service;
        }
        [HttpPost]
        public async Task<JsonResult> SepeteEkle(int UrunId)
        {
            int id = (int)HttpContext.Session.GetInt32("ID");
           await _SepetService.SepeteEkle(UrunId, id);
            return Json(UrunId);
        }
        [HttpPost]
        public async Task<JsonResult> SepettenCikar(int id)
        {
            var detay = await _service.getByIdAsync(id);
           await _service.Remove(detay);
          // await _SepetService.SepettenCikar(id);
            return Json(id);
        }
        //[HttpPost]
        public async Task<JsonResult> SepetiSil(int id)
        {
            var sepet = await _SepetService.getByIdAsync(id);
            await _SepetService.Remove(sepet);
            return Json(id);
        }
    }
}
