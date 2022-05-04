using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;


namespace StoreWeb.Controllers
{
    public class SepetController : Controller
    {
        private readonly ISepetService _SepetService;
        private readonly Sepet _sepet;
        public SepetController(ISepetService sepetService, Sepet sepet)
        {
            _SepetService = sepetService;
            _sepet = sepet;
        }
        [HttpPost]
        public JsonResult SepeteEkle(SepetDetayDto sepetDetayDto)
        {
            int id = 1;
            _SepetService.SepeteEkle(sepetDetayDto, id);
            return Json(sepetDetayDto);
        }
        [HttpPost]
        public JsonResult SepettenCikar(int Id)
        {
            _SepetService.SepettenCikar(Id);
            return Json(Id);
        }
        [HttpPost]
        public JsonResult SepetiSil(int id)
        {
            var sepet = _SepetService.getByIdAsync(id).Result;
            _SepetService.Remove(sepet);
            return Json(sepet.UyeId);
        }
    }
}
