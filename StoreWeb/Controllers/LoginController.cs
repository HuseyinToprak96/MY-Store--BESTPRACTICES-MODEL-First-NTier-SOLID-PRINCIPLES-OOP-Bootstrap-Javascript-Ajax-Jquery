using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUyeService _uyeService;
        public LoginController(IUyeService uyeService)
        {
            _uyeService = uyeService;
        }
        public IActionResult KullaniciGiris()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> KullaniciGiris(string Email,string Sifre)
        {
            var uyeBilgileri = await _uyeService.UyeLogin(Email, Sifre);
            if (uyeBilgileri != null) {
                HttpContext.Session.SetInt32("ID", uyeBilgileri.Id);
                HttpContext.Session.SetString("Yetki", uyeBilgileri.Yetki);
                
                return RedirectToAction( "Index","Page");
            }
            else
                TempData["Hata"] = "Hatalı kullanıcı adı veya şifre";
            // TempData["hata"] = "hata var";
            return RedirectToAction("KullaniciGiris");
        }
        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Page");
        }
    }
}
