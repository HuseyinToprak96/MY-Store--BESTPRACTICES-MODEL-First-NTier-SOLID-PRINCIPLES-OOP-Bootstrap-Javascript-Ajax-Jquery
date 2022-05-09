using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWeb.Controllers
{
    public class SiparisController : Controller
    {

        private readonly ISiparisService _siparisService;
        private readonly ISepetService _sepetService;

        public SiparisController(ISiparisService siparisService, ISepetService sepetService)
        {
            _siparisService = siparisService;
            _sepetService = sepetService;
        }
        [HttpPost]
        public async Task<JsonResult> SiparisVer()
        {
            int id = HttpContext.Session.GetInt32("ID").Value;
            var sepet = await _sepetService.MusterininSepeti(id);
            await _siparisService.SiparisOlustur(id);
            int siparisId =await _siparisService.SiparisBul(id);
            await _siparisService.SiparisleriEkle(sepet.SepetDetay,siparisId);
            await _sepetService.SepetiTemizle(sepet.Id);
            return Json(id);
        }
        public async Task<JsonResult> Puanla(int puan,int id)
        {
            await _siparisService.Puanla(puan, id);
            return Json(puan);
        }
    }
}
