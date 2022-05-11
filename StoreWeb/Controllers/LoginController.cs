using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StoreWeb.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IUyeService _uyeService;
        private readonly ISiparisService _siparisService;
        private readonly IMapper _mapper;
        public LoginController(IUyeService uyeService, IMapper mapper, ISiparisService siparisService)
        {
            _uyeService = uyeService;
            _mapper = mapper;
            _siparisService = siparisService;
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
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> UyeOl(UyeOlDto uyeOlDto)
        {
            if (ModelState.IsValid)
            {
               var kontrol=await _uyeService.MailKontrol(uyeOlDto.Mail);
                if (!kontrol)
                {
                var uye = _mapper.Map<Uye>(uyeOlDto);
                await _uyeService.AddAsync(uye);
                return RedirectToAction(nameof(KullaniciGiris)); }
                else
                {
                    TempData["MailHatasi"] = "Farklı bir mail adresi deneyiniz.";
                }
            }
            return RedirectToAction("UyeOl");
        }
        public IActionResult SifremiUnuttum()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SifremiUnuttum(string mail)
        {
            var kontrol = await _uyeService.MailKontrol(mail);
            if (kontrol==false)
            {
                TempData["Control"] = "Kayıtlı böyle bir mail bulunamadı";
            }
            else
            {
                try
                {
                    SmtpClient client = new SmtpClient("smtp@gmail.com", 587);
                    client.Credentials = new NetworkCredential("HuseyinToprak96@outlook.com", "*****");
                    client.EnableSsl = true;
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(mail, "HOŞGELDİN KRAL");
                    mailMessage.To.Add("HuseyinToprak96@outlook.com");
                    mailMessage.Subject = "Şifre Yenileme";
                    MailMessage Email = new MailMessage();
                    Email.From = new MailAddress("HuseyinToprak96@outlook.com");
                    Email.To.Add("hsyn_tprak_94@hotmail.com");
                    Email.Subject = "";
                    Email.Body = "güncellendi";
                    client.Send(Email);
                }
                catch
                {
                    TempData["islemHatasi"] = "İşlem sırasında bir hata oluştu.";
                }
            }
            return View();
        }
    }
}
