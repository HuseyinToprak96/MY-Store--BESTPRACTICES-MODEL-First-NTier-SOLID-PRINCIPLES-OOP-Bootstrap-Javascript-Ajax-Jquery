using AutoMapper;
using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWeb.Filters;
using System.Net;
using System.Net.Mail;
using System.Text;
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
        [FilterLogin]
        public async Task<IActionResult> Profilim()
        {
            int id = HttpContext.Session.GetInt32("ID").Value;
            return View(await _uyeService.uyeDetay(id));
        }
        [HttpPost]
        public async Task<JsonResult> BilgileriGuncelle(Uye uye)
        {
            //uye.cinsiyet = (Cinsiyet)1;
            await _uyeService.Update(uye);
            return Json(uye.Id);
        }
        [HttpPost]
        public async Task<JsonResult> MailGonder()
        {
            int id = HttpContext.Session.GetInt32("ID").Value;
            string mail= await _uyeService.MailBul(id);
            try
            {
                SmtpClient client = new SmtpClient("smtp@gmail.com", 587);
                client.Credentials = new NetworkCredential("HuseyinToprak96@outlook.com", "*****");
                client.EnableSsl = true;
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("hsyn_tprak_94@hotmail.com", "HOŞGELDİN KRAL");
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
                ViewBag.Hata = "Hata var";
            }



            return Json(id);
        }
    }
}
