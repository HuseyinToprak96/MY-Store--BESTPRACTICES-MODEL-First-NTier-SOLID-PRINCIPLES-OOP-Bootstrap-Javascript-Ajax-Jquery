using CoreLayer.Interfaces.Services;
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
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Login(string Email,string Sifre)
        {
          var uyeBilgileri= await _uyeService.UyeLogin(Email, Sifre);
            if(uyeBilgileri!=null)
            return RedirectToAction("Urun", "Index");
            else
            {
                TempData["Hata"] = "Hatalı kullanıcı adı veya şifre";
                return RedirectToAction("Login");
            }

        }
    }
}
