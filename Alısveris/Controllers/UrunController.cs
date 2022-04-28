using CoreLayer.Entities;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Services;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alısveris.Controllers
{
    public class UrunController : Controller
    {
        private readonly IUrunService _UrunService;
        public UrunController(IUrunService urunService)
        {
            _UrunService = urunService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _UrunService.getAllAsync());
        }
        public async Task<IActionResult> Detail(int id)
        {
            return View(await _UrunService.getByIdAsync(id));
        }
        public async Task<IActionResult> Urunler(int id)
        {
            return View(await _UrunService.AltKategoriyeGore(id));
        }
    }
}
