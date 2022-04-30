using CoreLayer.Dtos;
using CoreLayer.Entities;
using CoreLayer.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
namespace StoreWeb.Controllers
{
    public class VitrinController : Controller
    {
        private readonly IService<FaturaDetay> _faturaDetayservice; //En çok satan ürünler için
        private readonly IService<Urun> _Urunservice;//En son gelen 4 ürün
        private readonly IService<Kategori> _Kategoriservice;//Kategorileri listelerken kapak resmine en cok satan ürünü getirme


        public VitrinController(IService<FaturaDetay> faturDetayservice, IService<Urun> urunservice, IService<Kategori> kategoriservice)
        {
            _faturaDetayservice = faturDetayservice;
            _Urunservice = urunservice;
            _Kategoriservice = kategoriservice;
        }

        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult EncokSatan()
        {

            return PartialView();
        }
        public PartialViewResult EnsonGelen()
        {
            return PartialView();
        }
        public async Task<PartialViewResult> Kategoriler()
        {
          var kategoriler= await _Kategoriservice.getAllAsync();
            return PartialView();
        }
    }
}
