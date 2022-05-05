using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StoreWeb.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IUyeService _uyeService;
        private readonly IMapper _mapper;
        public LoginController(IUyeService uyeService, IMapper mapper)
        {
            _uyeService = uyeService;
            _mapper = mapper;
        }
        public IActionResult KullaniciGiris()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> KullaniciGiris(string Email, string Sifre)
        {
            var uyeBilgileri = await _uyeService.UyeLogin(Email, Sifre);
            if (uyeBilgileri != null)
            {
                HttpContext.Session.SetInt32("ID", uyeBilgileri.Id);
                if (uyeBilgileri.Yetki == true)
                {
                    HttpContext.Session.SetString("Yetki","Admin");
                    // string yetki = "Admin";
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role,"Admin")
                };
                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Index", "Page");
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
        public IActionResult UyeOl()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> UyeOl(UyeOlDto uyeOlDto)
        {
            return RedirectToAction("Login");
            if (ModelState.IsValid)
            {
                uyeOlDto.CinsiyetId = 2;
                var uye = _mapper.Map<Uye>(uyeOlDto);
               await _uyeService.AddAsync(uye);
                return RedirectToAction(nameof(KullaniciGiris));
            }
            return RedirectToAction("UyeOl");
        }

        public IActionResult UyeOl1()
        {
            return View();
        }
    }
}
