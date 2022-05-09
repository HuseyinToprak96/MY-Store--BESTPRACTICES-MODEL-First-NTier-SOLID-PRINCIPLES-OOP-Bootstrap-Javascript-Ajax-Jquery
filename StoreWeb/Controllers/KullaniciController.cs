using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWeb.Filters;
using System.Threading.Tasks;

namespace StoreWeb.Controllers
{
    [AllowAnonymous]
    public class KullaniciController : Controller
    {
        private readonly IUyeService _uyeService;
        public KullaniciController(IUyeService uyeService)
        {
            _uyeService = uyeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [FilterLogin]
        public async Task<IActionResult> Profilim()
        {
            int id = HttpContext.Session.GetInt32("ID").Value;
            return View(await _uyeService.uyeDetay(id));
        }
        [HttpPost]
        public async Task<JsonResult> BilgileriGuncelle(Uye uye)
        {
            uye.cinsiyet = (Cinsiyet)1;
            await _uyeService.Update(uye);
            return Json(uye.Id);
        }
        
    }
}
