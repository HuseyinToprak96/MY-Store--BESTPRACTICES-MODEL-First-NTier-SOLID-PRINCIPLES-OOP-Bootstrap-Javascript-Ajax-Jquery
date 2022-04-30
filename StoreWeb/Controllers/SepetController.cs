using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<JsonResult> SepeteEkle(SepetDetayDto sepetDetayDto)
        {
            int id = 1;
            await _SepetService.SepeteEkle(sepetDetayDto,id);
            return Json(sepetDetayDto);
        }
        [HttpPost]
        public JsonResult SepettenCikar(int sepetDetayId)
        {
            int id=1;
            _SepetService.SepettenCikar(sepetDetayId,id);
            return Json(id);
        }
    }
}
