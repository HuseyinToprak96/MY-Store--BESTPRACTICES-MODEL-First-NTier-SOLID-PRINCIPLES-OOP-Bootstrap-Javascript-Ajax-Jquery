using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace StoreWeb.Controllers
{
    public class MVCSepetController : Controller
    {
        private readonly ISepetService _SepetService;
     
        public MVCSepetController(ISepetService sepetService)
        {
            _SepetService = sepetService;
         
        }
        [HttpPost]
        public async Task<JsonResult> SepetEkle(int UrunId)
        {
           int id = (int)HttpContext.Session.GetInt32("ID");
           await _SepetService.SepeteEkle(UrunId, id);
           return Json(UrunId);
        }
        [HttpPost]
        public async Task<JsonResult> SepettenCikar(int id)
        {
            await _SepetService.SepettenCikar(id);
            return Json(id);
        }
        [HttpPost]
        public async Task<JsonResult> SepetiTemizle(int id)
        {
          await  _SepetService.SepetiTemizle(id);
            return Json(id);
        }
    }
}
